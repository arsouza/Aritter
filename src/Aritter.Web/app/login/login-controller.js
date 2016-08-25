(function () {
  'use strict';

  function LoginController($state, $stateParams, authenticationService) {
    var self = this;

    self.errors = [];

    self.viewMode = {
      login: true,
      register: false,
      forgot: false
    };

    self.switchViewMode = function (mode) {
      self.viewMode.login = self.viewMode.register = self.viewMode.forgot = false;
      self.viewMode[mode] = true;
    };

    self.login = function (userAccount) {
      authenticationService.login(userAccount)
        .then(function () {
          if ($stateParams.sref) {
            $state.go($stateParams.sref);
          } else {
            $state.go('main.home');
          }
        }, function (error) {
          self.errors = [];
          self.errors.push(error.error);
        });
    };

    self.register = function (userAccount) {
      authenticationService.register(userAccount)
        .then(function () {
          self.login(userAccount);
        });
    };
  }

  angular.module('aritter')
    .controller('LoginController', ['$state', '$stateParams', 'authenticationService', LoginController]);
})();
