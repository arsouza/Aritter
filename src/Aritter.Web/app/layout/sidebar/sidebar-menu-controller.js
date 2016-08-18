(function () {
  'use strict';

  function SidebarMenuController() {
    this.items = [];
  }

  angular.module('aritter')
    .controller('SidebarMenuController', [SidebarMenuController]);
})();
