'use strict';

(function () {
  angular.module('aritter').directive('toggleSubmenu', function () {

    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        element.click(function () {
          element.parent().toggleClass('toggled');
          element.parent().find('ul').stop(true, false).slideToggle(200);
        })
      }
    }
  })
})();
