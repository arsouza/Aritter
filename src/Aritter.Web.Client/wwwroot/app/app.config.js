'use strict';

(function () {
  angular.module('aritter').config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/home");

    $stateProvider

        //------------------------------
        // HOME
        //------------------------------
        .state('home', {
          url: '/home',
          templateUrl: 'app/components/home/home.html',
          resolve: {
            loadPlugin: function ($ocLazyLoad) {
              return $ocLazyLoad.load([
                  {
                    name: 'css',
                    insertBefore: '#app-level',
                    files: [
                      'assets/libs/fullcalendar/dist/fullcalendar.min.css',
                    ]
                  },
                  {
                    name: 'libs',
                    insertBefore: '#app-level-js',
                    files: [
                      'assets/libs/sparklines/jquery.sparkline.min.js',
                      'assets/libs/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js',
                      'assets/libs/simpleWeather/jquery.simpleWeather.min.js'
                    ]
                  }
              ])
            }
          }
        })
  });
})();
