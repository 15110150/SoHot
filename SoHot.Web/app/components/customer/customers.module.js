/// <reference path="../bower_components/angular/angular.js" />



(function () {
    angular.module('sohot.customers', ['sohot.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('customers', {
            url: "/customers",
            templateUrl: "/app/components/customer/customerListView.html",
            controller: "customerListController"

        })
           
    }
})();