(function () {
  'use strict';

  function NotificationService() {
    var defaults = {
      type: 'inverse',
      allow_dismiss: false,
      label: 'Cancel',
      className: 'btn-xs btn-inverse',
      placement: {
        from: 'top',
        align: 'right'
      },
      delay: 2500,
      animate: {
        enter: 'animated bounceIn',
        exit: 'animated bounceOut'
      },
      offset: {
        x: 20,
        y: 85
      }
    };

    this.configure = function (options) {
      defaults = angular.extend(defaults, options || {});
    };

    this.$get = [function () {
      return {
        defaults: defaults
      };
    }];
  }

  angular.module('aritter')
    .provider('notificationService', [NotificationService]);
})();
