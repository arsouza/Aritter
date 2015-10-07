'use strict';

(function () {
  angular.module('aritter').directive('mediaElement', function () {
    return {
      restrict: 'A',
      link: function (scope, element) {
        element.mediaelementplayer();
      }
    }
  })
})();
