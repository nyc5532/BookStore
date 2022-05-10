(function (app) {
    app.controller('categoryEditController', categoryEditController);
    categoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];

    function categoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.category = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateCategory = UpdateCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
        }

        function loadCategoryDetail() {
            apiService.get('api/category/getbyid/' + $stateParams.id,null, function(result) {
                $scope.category = result.data;
            }, function(error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateCategory() {
            apiService.put('api/category/update', $scope.category, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhập.');
                $state.go('categories');
            }, function (error) {
                notificationService.displayError('Cập nhập không thành công');
            });
        }
        function loadParentCategory() {
            apiService.get('/api/category/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Không Tìm Thấy Danh Mục');
            });
        }

        loadParentCategory();
        loadCategoryDetail();
    }
})(angular.module('bookstore.categories'));