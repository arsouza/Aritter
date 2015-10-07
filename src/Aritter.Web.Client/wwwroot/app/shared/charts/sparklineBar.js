'use strict';

(function () {
  angular.module('aritter').directive('sparklineBar', function () {

    return {
      restrict: 'A',
      link: function (scope, element) {
        function sparkLineBar(selector, values, height, barWidth, barColor, barSpacing) {
          $(selector).sparkline(values, {
            type: 'bar',
            height: height,
            barWidth: barWidth,
            barColor: barColor,
            barSpacing: barSpacing
          });
        }

        sparkLineBar('.stats-bar', [6, 4, 8, 6, 5, 6, 7, 8, 3, 5, 9, 5, 8, 4, 3, 6, 8], '45px', 3, '#fff', 2);
        sparkLineBar('.stats-bar-2', [4, 7, 6, 2, 5, 3, 8, 6, 6, 4, 8, 6, 5, 8, 2, 4, 6], '45px', 3, '#fff', 2);
      }
    }
  })
})();
