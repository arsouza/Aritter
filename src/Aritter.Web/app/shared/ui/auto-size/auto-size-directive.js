(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('autoSize', function () {
      return {
        restrict: 'A',
        link: function (scope, element) {
          if (element[0]) {
            autosize(element);
          }
        }
      };
    });
})();
