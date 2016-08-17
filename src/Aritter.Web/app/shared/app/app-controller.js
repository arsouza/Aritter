(function () {
  'use strict';

  function AppController($rootScope, $state, $timeout, messageService) {
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

    messageService.getNotifications().then(function (response) {
      self.notifications = response.data;
    });

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
  }

  angular.module('materialAdmin')
    .controller('AppController', ['$rootScope', '$state', '$timeout', 'messageService', AppController]);
})();
