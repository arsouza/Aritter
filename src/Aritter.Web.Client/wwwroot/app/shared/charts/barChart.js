'use strict';

(function () {
  angular.module('aritter').directive('barChart', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        var data1 = [[1, 60], [2, 30], [3, 50], [4, 100], [5, 10], [6, 90], [7, 85]];
        var data2 = [[1, 20], [2, 90], [3, 60], [4, 40], [5, 100], [6, 25], [7, 65]];
        var data3 = [[1, 100], [2, 20], [3, 60], [4, 90], [5, 80], [6, 10], [7, 5]];

        /* Create an Array push the data + Draw the bars*/

        var barData = new Array();

        barData.push({
          data: data1,
          label: 'Tokyo',
          bars: {
            show: true,
            barWidth: 0.08,
            order: 1,
            lineWidth: 0,
            fillColor: '#8BC34A'
          }
        });

        barData.push({
          data: data2,
          label: 'Seoul',
          bars: {
            show: true,
            barWidth: 0.08,
            order: 2,
            lineWidth: 0,
            fillColor: '#00BCD4'
          }
        });

        barData.push({
          data: data3,
          label: 'Beijing',
          bars: {
            show: true,
            barWidth: 0.08,
            order: 3,
            lineWidth: 0,
            fillColor: '#FF9800'
          }
        });

        /* Let's create the chart */
        $.plot($(element), barData, {
          grid: {
            borderWidth: 1,
            borderColor: '#eee',
            show: true,
            hoverable: true,
            clickable: true
          },

          yaxis: {
            tickColor: '#eee',
            tickDecimals: 0,
            font: {
              lineHeight: 13,
              style: "normal",
              color: "#9f9f9f",
            },
            shadowSize: 0
          },

          xaxis: {
            tickColor: '#fff',
            tickDecimals: 0,
            font: {
              lineHeight: 13,
              style: "normal",
              color: "#9f9f9f"
            },
            shadowSize: 0,
          },

          legend: {
            container: '.flc-bar',
            backgroundOpacity: 0.5,
            noColumns: 0,
            backgroundColor: "white",
            lineWidth: 0
          }
        });
      }
    }
  })
})();
