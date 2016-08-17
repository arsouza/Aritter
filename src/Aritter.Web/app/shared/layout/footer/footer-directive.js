(function () {
  'use strict';
  angular.module('aritter')
    .directive('maFooter', [function () {
      return {
        restrict: 'E',
        replace: true,
        templateUrl: 'app/shared/layout/footer/footer.html',
        require: ['^maApp', '^maLayout']
      };
    }]);
})();
