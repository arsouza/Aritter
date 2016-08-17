(function () {
  'use strict';

  function Header() {
    return {
      restrict: 'E',
      replace: true,
      templateUrl: 'app/shared/layout/header/header.html',
      require: ['^maApp', '^maLayout']
    };
  }

  angular.module('aritter')
    .directive('maHeader', [Header]);
})();
