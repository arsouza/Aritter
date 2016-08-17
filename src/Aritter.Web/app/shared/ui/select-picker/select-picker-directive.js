(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('selectPicker', function () {
      return {
        restrict: 'A',
        link: function (scope, element) {
          element.selectpicker();
        }
      };
    });
})();
