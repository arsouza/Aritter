(function () {
  'use strict';

  function SidebarController(authenticationService) {
    var self = this;

    self.userAccount = null;

    authenticationService.getCurrentUser()
      .then(function (currentUser) {
        self.userAccount = currentUser.account;
      });
  }

  angular.module('aritter')
    .controller('SidebarController', ['authenticationService', SidebarController]);
})();
