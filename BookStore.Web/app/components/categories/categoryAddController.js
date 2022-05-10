(function(app) {
    app.controller('categoryAddController', categoryAddController);
    categoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function categoryAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.category= {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.ckeditorOpitons = {
            language: 'vi',
            height:'200px'
        }
        $scope.AddCategory = AddCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
        }
        function AddCategory() {
                apiService.post('api/category/create', $scope.category, function(result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                $state.go('categories');
            },function(error) {
                notificationService.displayError('Thêm mới không thành công');
            });
        }
        function loadParentCategory() {
            apiService.get('/api/category/getallparents', null, function(result) {
                $scope.parentCategories = result.data;
            },function() {
                console.log('Không Tìm Thấy Danh Mục');
            });
        }

        loadParentCategory();
    }
})(angular.module('bookstore.categories'));