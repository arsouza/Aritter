'use strict';

(function () {
  angular.module('aritter').directive('inputMask', function () {
    return {
      restrict: 'A',
      scope: {
        inputMask: '='
      },
      link: function (scope, element) {
        element.mask(scope.inputMask.mask);
      }
    }
  })
})();
