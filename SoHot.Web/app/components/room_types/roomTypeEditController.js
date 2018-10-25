(function (app) {
    app.controller('roomTypeEditController', roomTypeEditController);

    roomTypeEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function roomTypeEditController(apiService, $scope, notificationService, $state, $stateParams, commonService ) {
        $scope.roomType = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.UpdateRoomType = UpdateRoomType;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.roomType.Alias = commonService.getSeoTitle($scope.roomType.Name);
        }

        function loadRoomTypeDetail() {
            apiService.get('/api/roomtype/getbyid/' + $stateParams.id, null, function (result) {
                $scope.roomType = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateRoomType() {
            apiService.put('/api/roomtype/update', $scope.roomType,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
                    $state.go('room_types');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        loadRoomTypeDetail();
    }

})(angular.module('sohot.room_types'));