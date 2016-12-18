/* 
namespace: Webjet.Movies.Web
data: 12/12/2016
objective: Home page controller
dev: adriano.galesso
*/

app.controller('HomeController', function ($scope, $location, Movie) {

    $scope.movies = [];
    $scope.loading = true;
    $scope.bug = '';

    $scope.init = function () {
        (new Movie()).get().then(function (response) {

            $scope.movies = response;
            $scope.loading = false;

        }, function (error) {
            $scope.bug = "Sorry our movies databases are offline. Please, try again later!"
        });
    };

    $scope.getDetails = function (movie) {
        var detailMovies = $scope.movies.filter(function (obj) { return obj.year === movie.year; });

        localStorage.setItem("detailMovies", angular.toJson(detailMovies.map(function (obj) {
            return {
                id: obj.id,
                database: obj.database
            }
        }), false));

        window.location.href = '#/movie/'.concat(movie.getURLTitle()).concat('/');
    }

    $scope.init();
});