'use strict';

(function () {
  angular.module('aritter').directive('html', ['nicescrollService', function (nicescrollService) {
    return {
      restrict: 'E',
      link: function (scope, element) {
        if (!element.hasClass('ismobile')) {
          if (!$('.login-content')[0]) {
            nicescrollService.niceScroll(element, 'rgba(0,0,0,0.3)', '5px');
          }
        }
      }
    }
  }])
})();
