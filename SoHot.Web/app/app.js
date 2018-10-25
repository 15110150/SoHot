/// <reference path="../bower_components/angular/angular.js" />



(function () {
    angular.module('sohot',
        ['sohot.rooms',
            'sohot.room_types',
            'sohot.customers',
            'sohot.reservations',
            'sohot.common'
        ]).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"

        });
        $urlRouterProvider.otherwise('/admin')
    }

  
})();