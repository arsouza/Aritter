(function () {
  'use strict';

  function MessageService($http) {
    this.getNotifications = function () {
      return $http.get('assets/data/messages-notifications.json');
    };
  }

  angular.module('aritter')
    .service('messageService', ['$http', MessageService]);
})();
