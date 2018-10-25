(function (app) {
    app.controller('reservationListController', reservationListController);
    reservationListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', 'commonService'];
    function reservationListController($scope, apiService, notificationService, $ngBootbox, commonService) {
        $scope.reservations = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getReservations = getReservations;
        $scope.keyword = '';
        $scope.search = search;
      


       
        function search() {
            getReservations();
        }
        function loadReservation() {
            apiService.get('/api/reservation/getallparents', null, function (result) {
                $scope.reservations = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        function getReservations() {
            loadReservation();
        }
        $scope.getReservations();
    }
})(angular.module('sohot.reservations'));