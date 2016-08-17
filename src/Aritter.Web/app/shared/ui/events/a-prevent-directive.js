(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('aPrevent', function () {
      return {
        restrict: 'C',
        link: function (scope, element) {
          element.on('click', function (event) {
            event.preventDefault();
          });
        }
      };
    });
})();
