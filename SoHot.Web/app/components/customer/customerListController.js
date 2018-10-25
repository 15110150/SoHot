(function (app) {
    app.controller('customerListController', customerListController);
    customerListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', 'commonService'];
    function customerListController($scope, apiService, notificationService, $ngBootbox, commonService) {
        $scope.customers = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCustomers = getCustomers;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteCustomer = deleteCustomer;


        function deleteCustomer(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/customer/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function search() {
            getCustomers();
        }
        function loadCustomer() {
            apiService.get('/api/customer/getallparents', null, function (result) {
                $scope.customers = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        function getCustomers() {
            loadCustomer();
        }
        $scope.getCustomers();
    }
})(angular.module('sohot.customers'));