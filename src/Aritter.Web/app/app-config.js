(function () {
  'use strict';
  angular.module('aritter')
    .config(['$stateProvider', '$urlRouterProvider', 'scrollbarServiceProvider', function ($stateProvider, $urlRouterProvider, scrollbarProvider) {

      scrollbarProvider.configure({
        theme: 'minimal-dark'
      });

      $urlRouterProvider.when('/', '/app/home');
      $urlRouterProvider.when('', '/app/home');
      $urlRouterProvider.otherwise('/404');

      $stateProvider

        //------------------------------
        // APP
        //------------------------------
        .state('main', {
          url: '/app',
          abstract: true,
          templateUrl: 'app/main/main.html',
          controller: 'MainController',
          controllerAs: 'mainCtrl',
          params: {
            authorize: true
          }
        })

        //------------------------------
        // HOME
        //------------------------------
        .state('main.home', {
          url: '/home',
          templateUrl: 'app/main/home/home.html',
          controller: 'HomeController',
          controllerAs: 'homeCtrl',
          params: {
            authorize: ['Users', 1]
          }
        })

        //------------------------------
        // USER PROFILE
        //------------------------------
        .state('main.userProfile', {
          url: '/user/{username}/profile',
          templateUrl: 'app/main/users/user-profile.html',
          controller: 'UserProfileController',
          controllerAs: 'userProfileCtrl',
          resolve: {
            user: ['$stateParams', 'authenticationService', function ($stateParams, authenticationService) {
              $stateParams.username = $stateParams.username || authenticationService.currentUser().username;
              return {
                username: $stateParams.username
              };
            }]
          }
        })

        //------------------------------
        // LOGIN
        //------------------------------
        .state('login', {
          url: '/login',
          templateUrl: 'app/login/login.html',
          controller: 'LoginController',
          controllerAs: 'loginCtrl',
          params: {
            sref: undefined
          }
        })

        //------------------------------
        // LOGIN
        //------------------------------
        .state('404', {
          url: '/404',
          templateUrl: 'app/404/404.html'
        });
    }]);
})();
