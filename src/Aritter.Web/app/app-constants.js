(function () {
  'use strict';
  angular.module('aritter')
    .constant('appEvents', {
      notification: 'NOTIFICATION'
    })
    .constant('httpEvents', {
      internalServerError: 'INTERNAL_SERVER_ERROR',
      forbidden: 'FORBIDDEN',
      unauthorized: 'UNAUTHORIZED',
      notFound: 'NOT_FOUND',
      success: 'SUCCESS',
      badRequest: 'BAD_REQUEST',
      unexpected: 'UNEXPECTED'
    })
    .constant('apiConfig', {
      clientId: '98E74CCE-D1EA-4D6A-80ED-A25D030EF69F',
      authentication: {
        host: 'http://localhost/Aritter.API/',
        routes: {
          token: 'api/token',
          getCurrentAccount: 'api/v1/account',
          registerAccount: 'api/v1/accounts'
        }
      }
    });
})();
