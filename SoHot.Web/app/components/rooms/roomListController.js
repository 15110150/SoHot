(function (app) {
    app.controller('roomListController', roomListController);
    roomListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function roomListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.rooms = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getRooms = getRooms;
        $scope.loadRoom = loadRoom;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteRoom = deleteRoom;


        function deleteRoom(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/room/delete', config, function () {
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
        function loadRoom() {
            apiService.get('/api/room/getallparents', null, function (result) {
                $scope.rooms = result.data;
            }, function () {
                console.log('Cannot get list' );
            });
        }
        function getRooms(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('/api/room/getallparents', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                else {
                    notificationService.displaySuccess('Đã thấy.');
                }
                $scope.rooms = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;

            }, function () {
                console.log('load room type fail.')
            });
        }
        $scope.loadRoom();
    }
})(angular.module('sohot.rooms'));