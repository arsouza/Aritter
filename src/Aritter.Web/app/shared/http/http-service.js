(function () {
  'use strict';

  function HttpService($injector, $q, $http, httpEvents) {

    var getRequestParams = function (config) {
      if (!config || !config.params) {
        return undefined;
      }
      return config.params;
    };

    var getRequestHeaders = function (config) {
      if (!config || !config.headers) {
        return undefined;
      }
      return config.headers;
    };

    var httpRequest = function (method, url, data, config, refreshToken) {

      var statusToRefresh = {
        401: httpEvents.unauthorized,
        403: httpEvents.forbbiden
      };

      var deferred = $q.defer();

      var req = {
        method: method,
        url: url,
        data: data,
        headers: getRequestHeaders(config),
        params: getRequestParams(config)
      };

      $http(req).then(function (response) {
        deferred.resolve(response);
      }, function (rejection) {
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
      });

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
