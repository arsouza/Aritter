(function () {
  'use strict';

  function HomeController($scope, $state, appEvents) {
    this.$state = $state;
    $scope.$emit(appEvents.notification, { message: 'Test' });
  }

  angular.module('materialAdmin')
    .controller('HomeController', ['$scope', '$state', 'appEvents', HomeController]);
})();
