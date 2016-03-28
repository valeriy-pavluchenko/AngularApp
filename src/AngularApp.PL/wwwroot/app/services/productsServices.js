(function () {
    'use strict';
    var productsServices = angular.module('productsServices', ['ngResource']);

    productsServices.factory('Products', ['$resource',
      function ($resource) {
          return $resource('/api/product/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);

})();