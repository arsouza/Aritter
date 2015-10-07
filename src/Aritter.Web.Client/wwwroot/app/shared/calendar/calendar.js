'use strict';

(function () {
  angular.module('aritter').directive('calendar', function ($compile) {
    return {
      restrict: 'A',
      scope: {
        select: '&',
        actionLinks: '=',
      },
      link: function (scope, element, attrs) {

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        //Generate the Calendar
        element.fullCalendar({
          header: {
            right: '',
            center: 'prev, title, next',
            left: ''
          },

          theme: true, //Do not remove this as it ruin the design
          selectable: true,
          selectHelper: true,
          editable: true,

          //Add Events
          events: [
              {
                title: 'Hangout with friends',
                start: new Date(y, m, 1),
                allDay: true,
                className: 'bgm-cyan'
              },
              {
                title: 'Meeting with client',
                start: new Date(y, m, 10),
                allDay: true,
                className: 'bgm-red'
              },
              {
                title: 'Repeat Event',
                start: new Date(y, m, 18),
                allDay: true,
                className: 'bgm-blue'
              },
              {
                title: 'Semester Exam',
                start: new Date(y, m, 20),
                allDay: true,
                className: 'bgm-green'
              },
              {
                title: 'Soccor match',
                start: new Date(y, m, 5),
                allDay: true,
                className: 'bgm-purple'
              },
              {
                title: 'Coffee time',
                start: new Date(y, m, 21),
                allDay: true,
                className: 'bgm-orange'
              },
              {
                title: 'Job Interview',
                start: new Date(y, m, 5),
                allDay: true,
                className: 'bgm-dark'
              },
              {
                title: 'IT Meeting',
                start: new Date(y, m, 5),
                allDay: true,
                className: 'bgm-cyan'
              },
              {
                title: 'Brunch at Beach',
                start: new Date(y, m, 1),
                allDay: true,
                className: 'bgm-purple'
              },
              {
                title: 'Live TV Show',
                start: new Date(y, m, 15),
                allDay: true,
                className: 'bgm-orange'
              },
              {
                title: 'Software Conference',
                start: new Date(y, m, 25),
                allDay: true,
                className: 'bgm-blue'
              },
              {
                title: 'Coffee time',
                start: new Date(y, m, 30),
                allDay: true,
                className: 'bgm-orange'
              },
              {
                title: 'Job Interview',
                start: new Date(y, m, 30),
                allDay: true,
                className: 'bgm-dark'
              },
          ],

          //On Day Select
          select: function (start, end, allDay) {
            scope.select({
              start: start,
              end: end
            });
          }
        });


        //Add action links in calendar header
        element.find('.fc-toolbar').append($compile(scope.actionLinks)(scope));
      }
    }
  })
})();
