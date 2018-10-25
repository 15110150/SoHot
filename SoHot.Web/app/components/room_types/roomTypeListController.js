(function (app) {
    app.controller('roomTypeListController', roomTypeListController);
    roomTypeListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function roomTypeListController($scope, apiService, notificationService, $ngBootbox ) {
        $scope.roomTypes = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getRoomTypes = getRoomTypes;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteRoomType = deleteRoomType;

       
        function deleteRoomType(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/roomtype/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function search() {
            getRoomTypes();
        }
        function loadRoomType() {
            apiService.get('/api/roomtype/getallparents', null, function (result) {
                $scope.roomTypes = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        function getRoomTypes() {
            loadRoomType();
        } 
        $scope.getRoomTypes();
    }
})(angular.module('sohot.room_types'));