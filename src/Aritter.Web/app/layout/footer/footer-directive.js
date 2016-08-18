(function () {
  'use strict';
  angular.module('aritter')
    .directive('arFooter', [function () {
      return {
        restrict: 'E',
        replace: true,
        templateUrl: 'app/layout/footer/footer.html',
        require: ['^arApp', '^arLayout']
      };
    }]);
})();
