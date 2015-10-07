'use strict';

(function () {
  angular.module('aritter').directive('stopPropagate', function () {
    return {
      restrict: 'C',
      link: function (scope, element) {
        element.on('click', function (event) {
          event.stopPropagation();
        });
      }
    }
  })
})();
