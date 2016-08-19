(function () {
  'use strict';

  angular.module('aritter')
    .factory('httpInterceptor', ['$q', function ($q) {

      var isJsonResponse = function (response) {
        return typeof response.data === 'object';
      };

      var isTokenRequest = function (config) {
        return /grant_type=password/.test(config.data);
      };

      var isRefreshTokenRequest = function (config) {
        return /grant_type=refresh_token/.test(config.data);
      };

      var isExternalRequest = function (config) {
        return /^((http|https):\/\/)/.test(config.url);
      };

      return {
        request: function (config) {
          return $q.resolve(config);
        },

        requestError: function (rejection) {
          return $q.reject(rejection);
        },

        response: function (response) {
          if (!isExternalRequest(response.config)) {
            return $q.resolve(response);
          }

          if (isTokenRequest(response.config) || isRefreshTokenRequest(response.config)) {
            return $q.resolve(response);
          }

          if (isJsonResponse(response)) {
            if (response.data.success) {
              return $q.resolve(response);
            }
            return $q.reject(response);
          }

          return $q.resolve(response);
        },

        responseError: function (rejection) {
          return $q.reject(rejection);
        }
      };

    }]);
})();
