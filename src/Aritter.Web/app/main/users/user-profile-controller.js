(function () {
  'use strict';

  function UserProfileController(user) {
    console.log(user);
  }

  angular.module('aritter')
    .controller('UserProfileController', ['user', UserProfileController]);
})();
