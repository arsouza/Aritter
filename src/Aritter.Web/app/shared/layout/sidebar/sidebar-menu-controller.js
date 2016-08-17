(function () {
  'use strict';

  function SidebarMenuController() {
    this.items = [];
  }

  angular.module('materialAdmin')
    .controller('SidebarMenuController', [SidebarMenuController]);
})();
