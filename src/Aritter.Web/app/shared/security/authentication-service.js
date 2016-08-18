(function () {
  'use strict';

  function AuthenticationService($q, $timeout) {
    var self = this;

    var authenticationData = {
      isAuthenticated: false,
      currentUser: null
    };

    self.isAuthenticated = function () {
      return authenticationData.isAuthenticated;
    };

    self.isAuthorized = function (authorization) {
      if (!authorization || authorization === true) {
        return true;
      }

      return true;
    };

    self.currentUser = function () {
      return authenticationData.currentUser;
    };

    self.login = function (user) {
      var deferred = $q.defer();

      $timeout(function () {
        authenticationData.isAuthenticated = true;
        authenticationData.currentUser = {
          username: user.username
        };
        deferred.resolve({});
      }, 2000);

      return deferred.promise;
    };

    self.logout = function () {
      var deferred = $q.defer();

      $timeout(function () {
        authenticationData.isAuthenticated = false;
        authenticationData.currentUser = null;
        deferred.resolve({});
      }, 2000);

      return deferred.promise;
    };
  }

  angular.module('aritter')
    .service('authenticationService', ['$q', '$timeout', AuthenticationService]);
})();
