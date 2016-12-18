/* 
namespace: Webjet.Movies.Web
data: 11/12/2016
objective: General main module and index controller
dev: adriano.galesso
*/

var app = angular.module("moviesApp", [
    'ngRoute',
    'angular.filter',
    'movieModule'
]);

app.controller('IndexController', function ($scope, $location) {
    $scope.init = function () {

    };
});

app.config(['$routeProvider', function ($routeProvider) {
    
    $routeProvider
    .when('/', {
        templateUrl: '/pages/home.html',
        controller: 'HomeController'
    })
    .when('/movie/:movieName', {
        templateUrl: '/pages/details.html',
        controller: 'MovieDetailController'
    })
    .otherwise({ redirectTo: '/' });
}]);