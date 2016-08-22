(function () {
  'use strict';

  function LoginController($state, $stateParams, authenticationService) {
    var self = this;

    self.viewMode = {
      login: true,
      register: false,
      forgot: false,
    };

    self.switchViewMode = function (mode) {
      self.viewMode.login = false;
      self.viewMode.register = false;
      self.viewMode.forgot = false;
      self.viewMode[mode] = true;
    };

    self.login = function (user) {
      authenticationService.login(user)
        .then(function () {
          if ($stateParams.sref) {
            $state.go($stateParams.sref);
          } else {
            $state.go('main.home');
          }
        });
    };
  }

  angular.module('aritter')
    .controller('LoginController', ['$state', '$stateParams', 'authenticationService', LoginController]);
})();
