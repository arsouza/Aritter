'use strict';

(function () {
  angular.module('aritter').directive('cOverflow', ['nicescrollService', function (nicescrollService) {
    return {
      restrict: 'C',
      link: function (scope, element) {

        if (!$('html').hasClass('ismobile')) {
          nicescrollService.niceScroll(element, 'rgba(0,0,0,0.5)', '5px');
        }
      }
    }
  }])
})();
