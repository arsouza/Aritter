(function () {
  'use strict';
  angular.module('aritter')
    .directive('formControl', function () {
      return {
        restrict: 'C',
        require: '^arApp',
        link: function (scope, element, attrs, ctrl) {
          if (ctrl.ie9) {
            $('input, textarea').placeholder({
              customClass: 'ie9-placeholder'
            });
          }
        }
      };
    });
})();
