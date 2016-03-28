(function () {
    'use strict';

    angular
        .module('productsApp')
        .controller('categoriesController', categoriesController);

    categoriesController.$inject = ['$scope', '$http', 'Categories'];

    function categoriesController($scope, $http, Categories) {
        $scope.title = 'categoriesController';
        $scope.Categories = Categories.query();

        $scope.get = function () {
            $http({
                method: 'GET',
                url: '/api/category/'
            }).
            success(function (data) {
                $scope.Categories = data;
            });
        }
    }
})();
