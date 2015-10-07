'use strict';

(function () {
  angular.module('aritter').directive('swalImg', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        element.click(function () {
          swal({
            title: "Sweet!",
            text: "Here's a custom image.",
            imageUrl: "assets/img/thumbs-up.png"
          });
        });
      }
    }
  })
})();
