(function () {
  'use strict';
  angular.module('aritter')
    .directive('inputMask', function () {
      return {
        restrict: 'A',
        link: function (scope, element, attrs) {
          element.mask(attrs.inputMask);
        }
      };
    });
})();
