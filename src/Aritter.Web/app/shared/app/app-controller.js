(function () {
  'use strict';

  function AppController($rootScope, $state, $timeout, messageService, authenticationService) {
    var self = this;

    self.$state = $state;

    self.ie9 = false;
    self.mobile = false;
    self.layoutToggled = angular.fromJson(localStorage.getItem('ma-layout-toggled') || 'false');

    self.layoutToggle = function () {
      localStorage.setItem('ma-layout-toggled', self.layoutToggled);
    };

    self.isIE9 = function (isIE9) {
      self.ie9 = isIE9 || false;
    };

    self.ismobile = function (ismobile) {
      self.mobile = ismobile;
    };

    self.logout = function () {
      authenticationService.logout()
      .then(function () {
        $state.go('login');
      });
    };

    self.clearNotifications = function ($event) {
      $event.preventDefault();
      self.notifications.list = self.notifications.list || [];

      var timeout = 0;
      self.notifications.list.forEach(function (notification) {
        $timeout(function () {
          notification.removed = true;
        }, timeout += 150);
      });

      var notificationsLength = self.notifications.list.length;

      $timeout(function () {
        self.notifications.list = self.notifications.list.filter(function (notification) {
          return !notification.removed;
        });
      }, (notificationsLength * 150) + 200);
    };

    var init = function () {
      messageService.getNotifications().then(function (response) {
        self.notifications = response.data;
      });
    };

    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState) {

      if (toParams.authorize) {
        authenticationService.getCurrentUser()
          .then(function (currentUser) {
            if (!currentUser.isAuthenticated) {
              event.preventDefault();
              $state.go('login', { sref: toState.name });
            }
            else if (!authenticationService.isAuthorized((toState.params || {}).authorize)) {
              event.preventDefault();
              $state.go('404');
            }

            if (toState.name === 'login') {
              if (currentUser.isAuthenticated) {
                event.preventDefault();
                if (!fromState.name) {
                  $state.go('main.home');
                }
              }
            }
          });
      }
    });

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
      // to be used for back button //won't work when page is reloaded.
      $rootScope.previousState = {
        name: fromState.name,
        params: fromParams
      };
    });

    //back button function called from back button's ng-click='back()'
    $rootScope.back = function () {
      var previousState = $rootScope.previousState;
      $state.go(previousState.name, previousState.params);
    };

    init();
  }

  angular.module('aritter')
    .controller('AppController', ['$rootScope', '$state', '$timeout', 'messageService', 'authenticationService', AppController]);
})();
