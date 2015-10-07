'use strict';

(function () {
  angular.module('aritter').directive('sparklinePie', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        function sparklinePie(select, values, width, height, sliceColors) {
          $(select).sparkline(values, {
            type: 'pie',
            width: width,
            height: height,
            sliceColors: sliceColors,
            offset: 0,
            borderWidth: 0
          });
        }

        if ($('.stats-pie')[0]) {
          sparklinePie('.stats-pie', [20, 35, 30, 5], 45, 45, ['#fff', 'rgba(255,255,255,0.7)', 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.2)']);
        }
      }
    }
  })
})();
