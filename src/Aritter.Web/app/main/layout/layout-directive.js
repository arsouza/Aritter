(function () {
  'use strict';

  function Layout() {
    return {
      restrict: 'E',
      replace: true,
      transclude: true,
      controller: 'LayoutController',
      controllerAs: '$layout',
      templateUrl: 'app/main/layout/layout.html',
      require: ['^arApp', 'arLayout'],
      link: function (scope, elem, attrs, ctrls) {
        var $layout = ctrls[1];
        $layout.menuItems = (scope.$eval(attrs.menuItems || '') || []);
        $layout.chatUsers = (scope.$eval(attrs.chatUsers || '') || []);
        $layout.logout = attrs.logout;
      }
    };
  }

  angular.module('aritter')
    .directive('arLayout', [Layout]);
})();
