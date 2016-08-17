(function () {
  'use strict';
  angular.module('aritter')
    .directive('maScrollbar', ['maScrollbarService', function (maScrollbarService) {
      return {
        restrict: 'A',
        require: '^maApp',
        link: function (scope, element, attrs, ctrl) {
          var scrollbar = function (selector) {
            $(selector).mCustomScrollbar(maScrollbarService.defaults);
          };
          if (!ctrl.mobile) {
            scrollbar(element);
          }
        }
      };
    }]);
})();
