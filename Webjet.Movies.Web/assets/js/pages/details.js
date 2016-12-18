/* 
namespace: Webjet.Movies.Web
data: 13/12/2016
objective: Movie details page controller
dev: adriano.galesso
*/

app.controller('MovieDetailController', function ($scope, $location, Movie) {

    $scope.movies = [];
    $scope.detailsMovie = {};
    $scope.loading = true;
    $scope.bug = '';

    $scope.init = function () {
        let movies = angular.fromJson(localStorage.getItem("detailMovies"));

        (new Movie()).getDetails(movies).then(function (response) {

            $scope.movies = response;
            $scope.detailsMovie = $scope.movies[0];

            $scope.movies.sort(function (a, b) {
                return a.price > b.price;
            });

            $scope.movies[0].best = true;

            $scope.loading = false;

        }, function (error) {
            $scope.bug = "Sorry our movies databases are offline. Please, try again later!"
        });
    };

    $scope.getRatingNumber = function (rating) {

        if (rating) {
            var num = Math.round(rating / 2);
            return new Array(num);
        }


    }

    $scope.init();
});