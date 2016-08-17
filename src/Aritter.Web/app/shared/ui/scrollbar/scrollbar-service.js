(function () {
  'use strict';

  function ScrollbarService() {
    var defaults = {
      theme: 'light',
      scrollInertia: 100,
      axis: 'yx',
      mouseWheel: {
        enable: true,
        axis: 'y',
        preventDefault: true
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

  angular.module('materialAdmin')
    .provider('maScrollbarService', [ScrollbarService]);
})();
