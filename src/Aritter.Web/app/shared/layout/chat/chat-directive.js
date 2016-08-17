(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('maChat', [function () {
      return {
        restrict: 'E',
        replace: true,
        templateUrl: 'app/shared/layout/chat/chat.html',
        require: ['^maApp', '^maLayout']
      };
    }]);
})();
