(function () {
  'use strict';
  angular.module('aritter')
    .directive('arChat', [function () {
      return {
        restrict: 'E',
        replace: true,
        templateUrl: 'app/layout/chat/chat.html',
        require: ['^arApp', '^arLayout']
      };
    }]);
})();
