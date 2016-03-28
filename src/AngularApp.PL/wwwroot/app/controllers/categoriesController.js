(function () {
    'use strict';

    angular
        .module('productsApp')
        .controller('categoriesController', categoriesController);

    categoriesController.$inject = ['$scope', '$http', 'Categories'];

    function categoriesController($scope, $http, Categories) {
        $scope.title = 'categoriesController';
        $scope.Categories = Categories.query();
    }
})();
