(function () {
  'use strict';
  angular.module('materialAdmin')
    .controller('MainController', [function () {
      var self = this;

      self.menu = [
        {
          state: 'main.home',
          icon: 'zmdi zmdi-home',
          title: 'Dashboard'
        },
        {
          icon: 'zmdi zmdi-view-compact',
          title: 'Headers',
          children: [
            {
              state: 'headers.textual-menu',
              title: 'Textual menu'
            },
            {
              state: 'headers.image-logo',
              title: 'Image logo'
            },
            {
              state: 'headers.mainmenu-on-top',
              title: 'Mainmenu on top',
              children: [
                {
                  state: 'headers.textual-menu1',
                  title: 'Textual menu 1'
                },
                {
                  state: 'headers.textual-menu2',
                  title: 'Textual menu 2'
                }
              ]
            }
          ]
        }
      ];

      self.chatUsers = [
        {
          name: 'Jonathan Morris',
          avatar: 'assets/img/profile-pics/2.jpg',
          status: 'busy',
          state: 'Last seen 3 hours ago'
        },
        {
          name: 'Anderson Ritter',
          avatar: 'assets/img/profile-pics/4.jpg',
          state: 'Unavailable'
        },
        {
          name: 'David Belle',
          avatar: 'assets/img/profile-pics/1.jpg',
          status: 'online',
          state: 'Available'
        },
        {
          name: 'Jurema Soft',
          avatar: 'assets/img/profile-pics/5.jpg',
          status: 'offline',
          state: 'Offline'
        },
        {
          name: 'Fredric Mitchell Jr.',
          avatar: 'assets/img/profile-pics/3.jpg',
          status: 'online',
          state: 'Available'
        }
      ];

      self.logout = function () {
      };
    }]);
})();
