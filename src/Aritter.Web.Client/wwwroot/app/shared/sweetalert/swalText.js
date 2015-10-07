'use strict';

(function () {
  angular.module('aritter').directive('swalText', function () {
    return {
      restrict: 'A',
      link: function (scope, element, attrs) {
        element.click(function () {
          swal("Here's a message!", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem erat, tincidunt vitae ipsum et, pellentesque maximus enim. Mauris eleifend ex semper, lobortis purus sed, pharetra felis")

        });
      }
    }
  })
})();
