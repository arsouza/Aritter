(function () {
  'use strict';
  angular.module('aritter')
    .directive('maSidebar', [function () {
      return {
        restrict: 'E',
        replace: true,
        controller: 'SidebarController',
        controllerAs: '$sidebar',
        templateUrl: 'app/shared/layout/sidebar/sidebar.html',
        require: ['^maApp', '^maLayout'],
        link: function (scope, element, attrs, ctrls) {
          var $layout = ctrls[1];

          scope.$watch('$layout.profileMenuToggled', function (newVal, oldVal) {
            if (newVal || newVal !== oldVal) {
              element.find('.profile-menu .main-menu').slideToggle(200);
            }
          });

          scope.logout = function () {
            if ($layout.onLogout) {
              scope.$eval($layout.onLogout);
            }
          };
        }
      };
    }]);
})();
