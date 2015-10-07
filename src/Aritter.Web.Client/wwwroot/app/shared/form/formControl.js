'use strict';

(function () {
  angular.module('aritter').directive('formControl', function () {
    return {
      restrict: 'C',
      link: function (scope, element, attrs) {
        if (angular.element('html').hasClass('ie9')) {
          $('input, textarea').placeholder({
            customClass: 'ie9-placeholder'
          });
        }
      }
    }
  })
})();
