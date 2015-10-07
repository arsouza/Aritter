'use strict';

(function () {
  angular.module('aritter').directive('curvedlineChart', function () {
    return {
      restrict: 'A',
      link: function (scope, element) {

        /* Make some random data for the Chart*/

        var d1 = [];
        var d2 = [];
        var d3 = [];

        for (var i = 0; i <= 10; i += 1) {
          d1.push([i, parseInt(Math.random() * 30)]);
        }

        for (var i = 0; i <= 20; i += 1) {
          d2.push([i, parseInt(Math.random() * 30)]);
        }

        for (var i = 0; i <= 10; i += 1) {
          d3.push([i, parseInt(Math.random() * 30)]);
        }


        /* Chart Options */

        var options = {
          series: {
            shadowSize: 0,
            curvedLines: { //This is a third party plugin to make curved lines
              apply: true,
              active: true,
              monotonicFit: true
            },
            lines: {
              show: false,
              lineWidth: 0,
            },
          },
          grid: {
            borderWidth: 0,
            labelMargin: 10,
            hoverable: true,
            clickable: true,
            mouseActiveRadius: 6,

          },
          xaxis: {
            tickDecimals: 0,
            ticks: false
          },

          yaxis: {
            tickDecimals: 0,
            ticks: false
          },

          legend: {
            show: false
          }
        };

        /* Let's create the chart */

        $.plot($(element), [
            { data: d1, lines: { show: true, fill: 0.98 }, label: 'Product 1', stack: true, color: '#e3e3e3' },
            { data: d3, lines: { show: true, fill: 0.98 }, label: 'Product 2', stack: true, color: '#f1dd2c' }
        ], options);

        /* Tooltips for Flot Charts */

        if ($(".flot-chart")[0]) {
          $(".flot-chart").bind("plothover", function (event, pos, item) {
            if (item) {
              var x = item.datapoint[0].toFixed(2),
                  y = item.datapoint[1].toFixed(2);
              $(".flot-tooltip").html(item.series.label + " of " + x + " = " + y).css({ top: item.pageY + 5, left: item.pageX + 5 }).show();
            }
            else {
              $(".flot-tooltip").hide();
            }
          });

          $("<div class='flot-tooltip' class='chart-tooltip'></div>").appendTo("body");
        }
      }
    }
  })
})();
