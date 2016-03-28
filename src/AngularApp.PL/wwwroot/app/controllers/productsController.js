(function () {
    'use strict';

    angular
        .module('productsApp')
        .controller('productsController', productsController);

    productsController.$inject = ['$scope', '$http', 'Products'];

    function productsController($scope, $http, Products, Categories) {
        $scope.title = 'productsController';
        $scope.Products = Products.query();

        $scope.refresh = function () {
            $http({
                method: 'GET',
                url: '/api/product/'
            }).
            success(function (data) {
                $scope.Products = data;
            });
        }

        $scope.add = function () {
            $http({
                method: 'POST',
                url: '/api/product/',
                data: this.Product
            }).
            success(function () {
                $scope.Product = {};
                $scope.Products = Products.query();
            })
        }
    }
})();
