'use strict';

(function () {
  angular.module('aritter').directive('lightbox', function () {
    return {
      restrict: 'C',
      link: function (scope, element) {
        element.lightGallery({
          enableTouch: true
        });
      }
    }
  })
})();
