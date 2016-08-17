(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('maSidebarMenu', [function () {
      return {
        restrict: 'E',
        replace: true,
        controller: 'SidebarMenuController',
        controllerAs: '$menu',
        templateUrl: 'app/shared/layout/sidebar/sidebar-menu.html',
        require: ['^maApp', '^maLayout', '^maSidebar', 'maSidebarMenu'],
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
