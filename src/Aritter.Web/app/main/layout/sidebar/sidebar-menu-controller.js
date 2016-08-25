(function () {
  'use strict';

  function SidebarMenuController() {
    var self = this;
    self.items = [];
  }

  angular.module('aritter')
    .controller('SidebarMenuController', [SidebarMenuController]);
})();
