(function () {
  'use strict';
  angular.module('aritter')
    .directive('colorPicker', function () {
      return {
        restrict: 'A',
        link: function (scope, element) {
          $(element).each(function () {
            var colorOutput = $(this).closest('.cp-container').find('.cp-value');
            $(this).farbtastic(colorOutput);
          });
        }
      };
    });
})();
