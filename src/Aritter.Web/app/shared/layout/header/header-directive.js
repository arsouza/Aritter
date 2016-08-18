(function () {
  'use strict';

  function Header() {
    return {
      restrict: 'E',
      replace: true,
      templateUrl: 'app/shared/layout/header/header.html',
      require: ['^arApp', '^arLayout']
    };
  }

  angular.module('aritter')
    .directive('arHeader', [Header]);
})();
