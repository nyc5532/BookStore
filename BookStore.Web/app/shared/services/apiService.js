/// <reference path="D:\APTECH\Git\BookStore.Web\Assets/admin/libs/angular/angular.js" />
(function(app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http','notificationService','authenticationService'];

    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
    }
        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu đăng nhập');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }
        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function(result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu đăng nhập');
                } else if (failure!=null) {
                    failure(error);
                }
            });
        }
        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu đăng nhập');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }
        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function(result) {
                success(result);
            },function(error) {
                failure(error);
            });
        }
    }
})(angular.module('bookstore.common'));
