(function () {
    'use strict';

    angular
        .module('productsApp')
        .controller('productsController', productsController);

    productsController.$inject = ['$scope', '$http', 'Products'];

    function productsController($scope, $http, Products) {
        $scope.title = 'productsController';
        $scope.Products = Products.query();

        $scope.add = function () {
            if ($scope.form.$valid) {
                $http({
                    method: 'POST',
                    url: '/api/product/',
                    data: this.Product
                }).
                success(function () {
                    $scope.Product = {};
                    $scope.form.$setPristine();
                    $scope.Products = Products.query();
                })
            }
        }
    }
})();
