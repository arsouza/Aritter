(function () {
  'use strict';
  angular.module('aritter')
    .directive('arSidebar', [function () {
      return {
        restrict: 'E',
        replace: true,
        controller: 'SidebarController',
        controllerAs: '$sidebar',
        templateUrl: 'app/layout/sidebar/sidebar.html',
        require: ['^arApp', '^arLayout'],
        link: function (scope, element) {
          scope.$watch('$layout.profileMenuToggled', function (newVal, oldVal) {
            if (newVal || newVal !== oldVal) {
              element.find('.profile-menu .main-menu').slideToggle(200);
            }
          });
        }
      };
    }]);
})();
