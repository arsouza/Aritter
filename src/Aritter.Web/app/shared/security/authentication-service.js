(function () {
  'use strict';

  function AuthenticationService($q, $timeout, $http, $state, apiConfig, httpService) {
    var self = this;

    self.isAuthorized = function (authorization) {
      if (!authorization || authorization === true) {
        return true;
      }
      return true;
    };

    self.getCurrentUser = function () {
      var currentUser = angular.fromJson(localStorage.currentUser) || {
        account: null,
        authentication: null,
        isAuthenticated: false
      };

      return $q.resolve(currentUser);
    };

    var storeCurrentUserAccount = function (userAccount) {
      var deferred = $q.defer();

      self.getCurrentUser()
       .then(function (currentUser) {
         currentUser.account = userAccount;
         localStorage.currentUser = angular.toJson(currentUser);

         deferred.resolve(currentUser);
       });

      return deferred.promise;
    };

    var storeAuthenticationData = function (authentication) {
      var deferred = $q.defer();

      self.getCurrentUser()
       .then(function (currentUser) {
         currentUser.authentication = authentication;
         currentUser.isAuthenticated = true;
         localStorage.currentUser = angular.toJson(currentUser);

         deferred.resolve(currentUser);
       });

      return deferred.promise;
    };

    var configureBearer = function () {
      var deferred = $q.defer();

      self.getCurrentUser()
        .then(function (currentUser) {
          if (currentUser.isAuthenticated) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + currentUser.authentication.access_token;
            deferred.resolve();
          }
          else {
            deferred.reject();
          }
        });

      return deferred.promise;
    };

    var getAccountInfo = function () {
      var deferred = $q.defer();

      var url = apiConfig.security.host + apiConfig.security.routes.getAccountInfo;

      httpService.get(url)
        .then(function (response) {
          storeCurrentUserAccount(response.data);
        })
        .then(function (response) {
          deferred.resolve(response);
        }, function (error) {
          deferred.reject(error);
        });

      return deferred.promise;
    };

    var authenticate = function (data) {
      var defered = $q.defer();

      var config = {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded'
        }
      };

      var url = apiConfig.security.host + apiConfig.security.routes.token;

      httpService.post(url, data, config)
        .then(function (response) {
          storeAuthenticationData(response.data);
        })
        .then(function () {
          configureBearer();
        })
        .then(function () {
          getAccountInfo();
        })
        .then(function () {
          defered.resolve();
        }, function (error) {
          defered.reject(error.data);
        });

      return defered.promise;
    };

    self.login = function (user) {
      return authenticate('grant_type=password&username=' + user.username + '&password=' + user.password);
    };

    self.logout = function () {
      var deferred = $q.defer();

      self.getCurrentUser()
        .then(function (currentUser) {
          currentUser.account = null;
          currentUser.authentication = null;
          currentUser.isAuthenticated = false;
          localStorage.currentUser = angular.toJson(currentUser);

          delete $http.defaults.headers.common.Authorization;

          deferred.resolve();
        });

      return deferred.promise;
    };

    self.refreshToken = function () {
      var deferred = $q.defer();

      self.getCurrentUser()
        .then(function (currentUser) {
          if (currentUser.isAuthenticated) {
            authenticate('grant_type=refresh_token&refresh_token=' + currentUser.refresh_token)
              .then(function (response) {
                deferred.resolve(response);
              }, function (error) {
                deferred.reject(error);
              });
          } else {
            deferred.reject();
          }
        });

      return deferred.promise;
    };

    configureBearer();
  }

  angular.module('aritter')
    .service('authenticationService', ['$q', '$timeout', '$http', '$state', 'apiConfig', 'httpService', AuthenticationService]);
})();
