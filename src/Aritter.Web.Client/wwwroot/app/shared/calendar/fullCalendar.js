'use strict';

(function () {
  angular.module('aritter').directive('fullCalendar', function () {
    return {
      restrict: 'A',
      link: function (scope, element) {
        element.fullCalendar({
          contentHeight: 'auto',
          theme: true,
          header: {
            right: '',
            center: 'prev, title, next',
            left: ''
          },
          defaultDate: '2014-06-12',
          editable: true,
          events: [
              {
                title: 'All Day',
                start: '2014-06-01',
                className: 'bgm-cyan'
              },
              {
                title: 'Long Event',
                start: '2014-06-07',
                end: '2014-06-10',
                className: 'bgm-orange'
              },
              {
                id: 999,
                title: 'Repeat',
                start: '2014-06-09',
                className: 'bgm-lightgreen'
              },
              {
                id: 999,
                title: 'Repeat',
                start: '2014-06-16',
                className: 'bgm-blue'
              },
              {
                title: 'Meet',
                start: '2014-06-12',
                end: '2014-06-12',
                className: 'bgm-teal'
              },
              {
                title: 'Lunch',
                start: '2014-06-12',
                className: 'bgm-gray'
              },
              {
                title: 'Birthday',
                start: '2014-06-13',
                className: 'bgm-pink'
              },
              {
                title: 'Google',
                url: 'http://google.com/',
                start: '2014-06-28',
                className: 'bgm-bluegray'
              }
          ]
        });
      }
    }
  })
})();
