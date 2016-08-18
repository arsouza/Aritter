(function () {
  'use strict';
  angular.module('aritter')
    .directive('arSidebarMenu', [function () {
      return {
        restrict: 'E',
        replace: true,
        controller: 'SidebarMenuController',
        controllerAs: '$menu',
        templateUrl: 'app/main/layout/sidebar/sidebar-menu.html',
        require: ['^arApp', '^arLayout', '^arSidebar', 'arSidebarMenu'],
        link: function (scope, elem, attrs, ctrls) {
          var $menu = ctrls[3];

          var items = scope.$eval(attrs.items || '[]');
          angular.forEach(items, function (item) {
            item.hasChildren = (item.children || []).length > 0;
          });

          $menu.items = items;

          scope.toggleSubmenu = function ($event, item) {
            item.submenuToggled = !item.submenuToggled;
            angular.element($event.target).next().slideToggle(200);
          };
        }
      };
    }]);
})();
