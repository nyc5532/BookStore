(function(app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService'];

    function rootController($state, authData, loginService, $scope, authenticationService) {
        $scope.logOut = function () {
            loginSevice.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;
        //authenticationService.validateRequest();
    }
})(angular.module('bookstore'));