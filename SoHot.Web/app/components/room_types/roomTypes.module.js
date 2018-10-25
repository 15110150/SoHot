/// <reference path="../bower_components/angular/angular.js" />



(function () {
    angular.module('sohot.room_types', ['sohot.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('room_types', {
            url: "/room_types",
            templateUrl: "/app/components/room_types/roomTypeListView.html",
            controller: "roomTypeListController"

        })
        .state('add_room_type', {
            url: "/add_room_type",
            templateUrl: "/app/components/room_types/roomTypeAddView.html",
            controller: "roomTypeAddController"
            })
            .state('edit_room_type', {
                url: "/edit_room_type/:id",
                templateUrl: "/app/components/room_types/roomTypeEditView.html",
                controller: "roomTypeEditController"
            });
    }
})();