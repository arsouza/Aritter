(function () {
  'use strict';
  angular.module('aritter')
    .directive('btn', function () {
      return {
        restrict: 'C',
        require: '^arApp',
        link: function (scope, element) {
          if (element.hasClass('btn-icon') || element.hasClass('btn-float')) {
            Waves.attach(element, ['waves-circle']);
          } else if (element.hasClass('btn-light')) {
            Waves.attach(element, ['waves-light']);
          } else {
            Waves.attach(element);
          }
          Waves.init();
        }
      };
    });
})();
