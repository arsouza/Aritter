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
      clientId: '47df4ba6-2094-47d2-81e8-41f34153c726',
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
