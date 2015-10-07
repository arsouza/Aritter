'use strict';

(function () {
  angular.module('aritter').directive('sparklineLine', function () {

    return {
      restrict: 'A',
      link: function (scope, element) {
        function sparkLineLine(selector, values, width, height, lineColor, fillColor, lineWidth, maxSpotColor, minSpotColor, spotColor, spotRadius, hSpotColor, hLineColor) {
          $(selector).sparkline(values, {
            type: 'line',
            width: width,
            height: height,
            lineColor: lineColor,
            fillColor: fillColor,
            lineWidth: lineWidth,
            maxSpotColor: maxSpotColor,
            minSpotColor: minSpotColor,
            spotColor: spotColor,
            spotRadius: spotRadius,
            highlightSpotColor: hSpotColor,
            highlightLineColor: hLineColor
          });
        }

        sparkLineLine('.stats-line', [9, 4, 6, 5, 6, 4, 5, 7, 9, 3, 6, 5], 85, 45, '#fff', 'rgba(0,0,0,0)', 1.25, 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 3, '#fff', 'rgba(255,255,255,0.4)');
        sparkLineLine('.stats-line-2', [5, 6, 3, 9, 7, 5, 4, 6, 5, 6, 4, 9], 85, 45, '#fff', 'rgba(0,0,0,0)', 1.25, 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 3, '#fff', 'rgba(255,255,255,0.4)');
        sparkLineLine('.dash-widget-visits', [9, 4, 6, 5, 6, 4, 5, 7, 9, 3, 6, 5], '100%', '95px', 'rgba(255,255,255,0.7)', 'rgba(0,0,0,0)', 2, 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 'rgba(255,255,255,0.4)', 5, 'rgba(255,255,255,0.4)', '#fff');

      }
    }
  })
})();
