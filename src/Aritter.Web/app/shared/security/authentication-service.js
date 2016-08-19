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
      self.getCurrentUser()
       .then(function (currentUser) {
         currentUser.account = userAccount;
         localStorage.currentUser = angular.toJson(currentUser);

         return $q.resolve(currentUser);
       });
    };

    var storeAuthenticationData = function (authentication) {
      self.getCurrentUser()
       .then(function (currentUser) {
         currentUser.authentication = authentication;
         currentUser.isAuthenticated = true;
         localStorage.currentUser = angular.toJson(currentUser);

         return $q.resolve(currentUser);
       });
    };

    var configureBearer = function () {
      self.getCurrentUser()
        .then(function (currentUser) {
          if (currentUser.isAuthenticated) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + currentUser.authentication.access_token;
          }
        });
    };

    var getAccountInfo = function () {
      httpService.get(apiConfig.security.host + apiConfig.security.routes.getAccountInfo)
        .then(function (response) {
          storeCurrentUserAccount(response);
          return $q.resolve(response);
        }, function (error) {
          console.log(error);
          return $q.reject(error);
        });
    };

    var authenticate = function (data) {
      var defered = $q.defer();

      var config = {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded'
        }
      };

      httpService.post(apiConfig.security.host + apiConfig.security.routes.token, data, config)
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
      self.getCurrentUser()
        .then(function (currentUser) {
          currentUser.account = null;
          currentUser.authentication = null;
          currentUser.isAuthenticated = false;
          localStorage.currentUser = angular.toJson(currentUser);

          delete $http.defaults.headers.common.Authorization;

          return $q.resolve();
        });
    };

    self.refreshToken = function () {
      self.getCurrentUser()
        .then(function (currentUser) {
          if (currentUser.isAuthenticated) {
            authenticate('grant_type=refresh_token&refresh_token=' + currentUser.refresh_token);
            return $q.resolve();
          } else {
            $state.go('login', { sref: $state.current.name });
            return $q.reject();
          }
        });
    };

    configureBearer();
  }

  angular.module('aritter')
    .service('authenticationService', ['$q', '$timeout', '$http', '$state', 'apiConfig', 'httpService', AuthenticationService]);
})();
