/// <reference path="../bower_components/angular/angular.js" />



(function () {
    angular.module('sohot.reservations', ['sohot.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('reservations', {
            url: "/reservations",
            templateUrl: "/app/components/reservations/reservationListView.html",
            controller: "reservationListController"

        })

    }
})();