﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('bookstore.products', ['bookstore.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            
            .state('products', {
                url: "/products",
                parent:'base',
                templateUrl: "/app/components/products/productListView.html",
                controller: "productListController"
        }).state('add_products', {
            url: "/add_products",
            parent:'base',
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('edit_products', {
            url: "/edit_products/:id",
            parent: 'base',
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();