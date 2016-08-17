(function () {
  'use strict';
  angular.module('materialAdmin')
    .directive('maApp', ['appEvents', 'maNotificationService', function (appEvents, maNotificationService) {
      var defaults = maNotificationService.defaults;

      var growl = function (message, type) {
        var options = defaults;
        if (type) {
          options = angular.extend(options, { type: type });
        }
        $.growl({
          message: message
        }, options);
      };

      return {
        restrict: 'A',
        controller: 'AppController',
        controllerAs: '$app',
        require: 'maApp',
        link: function (scope, element, attrs, ctrl) {

          ctrl.isIE9(!!navigator.userAgent.match(/MSIE 9.0/));
          ctrl.ismobile(/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent));

          scope.$on(appEvents.notification, function (event, args) {
            growl(args.message, args.type);
          });
        }
      };
    }]);
})();
