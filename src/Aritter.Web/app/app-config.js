(function () {
  'use strict';
  angular.module('materialAdmin')
    .config(['$stateProvider', '$urlRouterProvider', 'maScrollbarServiceProvider', function ($stateProvider, $urlRouterProvider, maScrollbarProvider) {

      maScrollbarProvider.configure({
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
          controllerAs: 'mainCtrl'
        })

        //------------------------------
        // HOME
        //------------------------------
        .state('main.home', {
          url: '/home',
          templateUrl: 'app/main/home/home.html',
          controller: 'HomeController',
          controllerAs: 'homeCtrl'
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
            user: ['$stateParams', function ($stateParams) {
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
          controllerAs: 'loginCtrl'
        })

        //------------------------------
        // LOGIN
        //------------------------------
        .state('404', {
          url: '/404',
          templateUrl: 'app/404/404.html'
        });
    }])
    .run(['$rootScope', '$state', function ($rootScope, $state) {
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
    }]);
})();
