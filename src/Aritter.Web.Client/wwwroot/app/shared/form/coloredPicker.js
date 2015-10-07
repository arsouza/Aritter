'use strict';

(function () {
  angular.module('aritter').directive('coloredPicker', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        $(element).each(function () {
          var colorOutput = $(this).closest('.cp-container').find('.cp-value');
          $(this).farbtastic(colorOutput);
        });

      }
    }
  })
})();
