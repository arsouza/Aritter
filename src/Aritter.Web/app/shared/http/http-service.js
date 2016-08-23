(function () {
  'use strict';

  function HttpService($injector, $q, $http, httpEvents) {

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

    var httpRequest = function (method, url, data, config, refreshToken) {

      var deferred = $q.defer();

      var statusToRefresh = {
        401: httpEvents.unauthorized,
        403: httpEvents.forbbiden
      };

      var request = {
        method: method,
        url: url,
        data: data
      };

      if (config) {
        Object.keys(config).forEach(function (key) {
          request[key] = config[key];
        });
      }

      var success = function (response) {
        if (!isExternalRequest(response.config) || isTokenRequest(response.config) || isRefreshTokenRequest(response.config)) {
          deferred.resolve(response);
        } else if (isJsonResponse(response) && !response.data.success) {
          deferred.reject(response);
        } else {
          deferred.resolve(response);
        }
      };

      var error = function (rejection) {
        if (!refreshToken || !statusToRefresh[rejection.status]) {
          deferred.reject(rejection);
        }
        else {
          var authenticationService = $injector.get('authenticationService');
          authenticationService.refreshToken()
            .then(function () {
              httpRequest(method, url, data, config, false)
                .then(function (response) {
                  deferred.resolve(response);
                }, function (rejection) {
                  deferred.reject(rejection);
                });
            });
        }
      };

      $http(request).then(success, error);

      return deferred.promise;
    };

    var get = function (url, config) {
      return httpRequest('GET', url, undefined, config, true);
    };

    var post = function (url, data, config) {
      return httpRequest('POST', url, data, config, true);
    };

    var put = function (url, data, config) {
      return httpRequest('PUT', url, data, config, true);
    };

    var _delete = function (url, data, config) {
      return httpRequest('DELETE', url, data, config, true);
    };

    return {
      get: get,
      post: post,
      put: put,
      delete: _delete
    };
  }

  angular.module('aritter')
    .service('httpService', ['$injector', '$q', '$http', 'httpEvents', HttpService]);
})();
