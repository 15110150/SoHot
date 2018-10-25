(function (app) {
    app.controller('roomTypeAddController', roomTypeAddController);

    roomTypeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state','commonService'];

    function roomTypeAddController(apiService, $scope, notificationService, $state, commonService ) {
        $scope.roomType = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.AddRoomType = AddRoomType;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.roomType.Alias = commonService.getSeoTitle($scope.roomType.Name);
        }

        function AddRoomType() {
            apiService.post('/api/roomtype/create', $scope.roomType,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('room_types');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.roomType.Image = fileUrl;
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
    }

})(angular.module('sohot.room_types'));