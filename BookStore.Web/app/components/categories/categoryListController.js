(function (app) {
    app.controller('categoryListController', categoryListController);

    categoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function categoryListController($scope, apiService, notificationService, $ngBootbox) {

        $scope.Categories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteCategory = deleteCategory;

        function deleteCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/category/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword : $scope.keyword,
                    page: page,
                    pageSize : 10
                }
            }
            apiService.get('/api/category/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.Categories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function() {
                console.log('Load category failed.');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('bookstore.categories'));