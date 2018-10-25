/// <reference path="../../../bower_components/angular/angular.js" />




(function () {
    angular.module('sohot.rooms', ['sohot.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('rooms', {
            url: "/rooms",
            templateUrl: "/app/components/rooms/roomListView.html",
            controller: "roomListController"

        }).state('rooms_add', {
            url: "/rooms_add",
            templateUrl: "/app/components/rooms/roomAddView.html",
            controller: "roomAddController"
            }).state('edit_room', {
                url: "/edit_room/:id",
                templateUrl: "/app/components/rooms/roomEditView.html",
                controller: "roomEditController"
            });
    }
})();