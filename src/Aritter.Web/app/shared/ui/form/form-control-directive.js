(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('formControl', function () {
      return {
        restrict: 'C',
        require: '^maApp',
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
