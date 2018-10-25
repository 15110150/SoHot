(function (app) {
    app.controller('roomAddController', roomAddController);

    roomAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function roomAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.room = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.AddRoom = AddRoom;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.room.Alias = commonService.getSeoTitle($scope.room.Name);
        }


        function AddRoom() {
            $scope.room.MoreImages = JSON.stringify($scope.moreImages)
            apiService.post('/api/room/create', $scope.room,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('rooms');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
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
    }

})(angular.module('sohot.rooms'));