(function () {
  'use strict';
  angular.module('aritter')
    .directive('selectPicker', function () {
      return {
        restrict: 'A',
        link: function (scope, element) {
          element.selectpicker();
        }
      };
    });
})();
