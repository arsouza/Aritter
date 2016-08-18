(function () {
  'use strict';
  angular.module('aritter')
    .directive('arScrollbar', ['scrollbarService', function (scrollbarService) {
      return {
        restrict: 'A',
        require: '^arApp',
        link: function (scope, element, attrs, ctrl) {
          var scrollbar = function (selector) {
            $(selector).mCustomScrollbar(scrollbarService.defaults);
          };
          if (!ctrl.mobile) {
            scrollbar(element);
          }
        }
      };
    }]);
})();
