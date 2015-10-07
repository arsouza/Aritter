'use strict';

(function () {
  angular.module('aritter').directive('selectPicker', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        //if (element[0]) {
        element.selectpicker();
        //}
      }
    }
  })
})();
