(function () {
  'use strict';
  angular.module('aritter')
    .directive('mustBeValue', function () {
      return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ctrl) {
          ctrl.$validators.mustBeValue = function (modelValue) {
            return !ctrl.$isEmpty(modelValue) && scope.$eval(attrs.mustBeValue) === modelValue;
          };
        }
      };
    });
})();
