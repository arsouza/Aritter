(function () {
  'use strict';

  function LayoutController($scope, $state, $timeout) {
    var self = this;

    self.$state = $state;

    self.currentSkin = localStorage.getItem('ma-current-skin') || 'blue';

    self.sidebarToggled = false;
    self.chatToggled = false;
    self.profileMenuToggled = false;

    self.chatUsers = [];
    self.menuItems = [];

    self.skinList = [
      'lightblue',
      'bluegray',
      'cyan',
      'teal',
      'green',
      'orange',
      'blue',
      'purple'
    ];

    self.resetSidebar = function (event) {
      if (!angular.element(event.target).parent().hasClass('active')) {
        self.sidebarToggled = false;
      }
    };

    self.skinSwitch = function (skin) {
      self.currentSkin = skin;
      localStorage.setItem('ma-current-skin', skin);
    };

    self.logout = function (logoutAttr) {
      if (logoutAttr !== undefined) {
        $timeout(function () {
          $scope.$eval(logoutAttr);
        });
      }
    };
  }

  angular.module('materialAdmin')
    .controller('LayoutController', ['$scope', '$state', '$timeout', LayoutController]);
})();
