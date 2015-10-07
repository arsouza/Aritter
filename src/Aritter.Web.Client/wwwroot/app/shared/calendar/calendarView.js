'use strict';

(function () {
  angular.module('aritter').directive('calendarView', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        element.on('click', function () {
          $('#calendar').fullCalendar('changeView', attrs.calendarView);
        })
      }
    }
  })
})();
