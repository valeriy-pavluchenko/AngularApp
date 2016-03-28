(function () {
    'use strict';
    var categoriesServices = angular.module('categoriesServices', ['ngResource']);

    categoriesServices.factory('Categories', ['$resource',
      function ($resource) {
          return $resource('/api/category/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);

})();