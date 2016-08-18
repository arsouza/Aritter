(function () {
  'use strict';

  angular.module('aritter')
    .factory('httpInterceptor', ['$q', function ($q) {

      return {
        request: function (config) {
          return $q.resolve(config);
        },

        requestError: function (rejection) {
          return $q.reject(rejection);
        },

        response: function (response) {
          return $q.resolve(response);
        },

        responseError: function (rejection) {
          return $q.reject(rejection);
        }
      };

    }]);
})();
