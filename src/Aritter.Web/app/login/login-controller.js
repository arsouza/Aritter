(function () {
  'use strict';
  angular.module('aritter')
    .controller('LoginController', ['$state', function ($state) {
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
        console.log(user);
        $state.go('main.home');
      };
    }]);
})();
