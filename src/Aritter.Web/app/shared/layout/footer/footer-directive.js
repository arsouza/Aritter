(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('maFooter', [function () {
      return {
        restrict: 'E',
        replace: true,
        templateUrl: 'app/shared/layout/footer/footer.html',
        require: ['^maApp', '^maLayout']
      };
    }]);
})();
