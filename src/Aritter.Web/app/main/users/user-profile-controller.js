(function () {
  'use strict';

  function UserProfileController(user) {
    console.log(user);
  }

  angular.module('materialAdmin')
    .controller('UserProfileController', ['user', UserProfileController]);
})();
