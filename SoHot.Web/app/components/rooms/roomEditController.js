(function (app) {
    app.controller('roomEditController', roomEditController);

    roomEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function roomEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.room = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.UpdateRoom = UpdateRoom;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.room.Alias = commonService.getSeoTitle($scope.room.Name);
        }

        function loadRoomDetail() {
            apiService.get('/api/room/getbyid/' + $stateParams.id, null, function (result) {
                $scope.room = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateRoom() {
            $scope.room.MoreImages = JSON.stringify($scope.moreImages)
            apiService.put('/api/room/update', $scope.room,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
                    $state.go('rooms');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadRoomType() {
            apiService.get('/api/roomtype/getallparents', null, function (result) {
                $scope.roomTypes = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.room.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })

            }
            finder.popup();
        }

        loadRoomType();
        loadRoomDetail();
    }

})(angular.module('sohot.rooms'));