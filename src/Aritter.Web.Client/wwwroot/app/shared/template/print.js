'use strict';

(function () {
  angular.module('aritter').directive('print', function () {
    return {
      restrict: 'A',
      link: function (scope, element) {
        element.click(function () {
          window.print();
        })
      }
    }
  })
})();
