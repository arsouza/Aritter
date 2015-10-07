'use strict';

(function () {
  angular.module('aritter').directive('swalTimer', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        element.click(function () {
          swal({
            title: "Auto close alert!",
            text: "I will close in 2 seconds.",
            timer: 2000,
            showConfirmButton: false
          });
        });
      }
    }
  })
})();
