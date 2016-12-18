/* 
namespace: Webjet.Movies.Web
data: 13/12/2016
objective: General movie object
dev: adriano.galesso
*/

var movieModule = angular.module('movieModule', ['baseModule', 'objectModule']);

movieModule.factory('Movie', ['$http', 'Base', 'ObjectUtils',
    function ($http, Base, ObjectUtils) {

        var api = environment.concat('movie/');

        var Movie = function (movie) {

            if (!movie) {
                movie = {};
            }

            Base.apply(this, [movie]);

            this.id = movie.id;
            this.title = movie.title;
            this.year = movie.year;
            this.poster = movie.poster;
            this.rating = movie.rating;
            this.votes = movie.votes;
            this.type = movie.type;
            this.price = movie.price;
            this.database = movie.database;
            this.actors = movie.actors;
            this.country = movie.country;
            this.director = movie.director;
            this.genre = movie.genre;
            this.language = movie.language;
            this.metascore = movie.metascore;
            this.plot = movie.plot;
            this.rated = movie.rated;
            this.released = movie.released;
            this.runtime = movie.runtime;
            this.writer = movie.writer;
        };

        Movie.prototype = new Base();

        Movie.prototype.get = function (database) {
            var self = this;

            return $http.get(api).then(function (response) {
                var movies = [];

                for (var i = 0; i < response.data.length; i++) {
                    movies.push(new Movie(response.data[i]));
                }

                return movies;
            },
            function (err) {
                throw err.data;
            });
        }

        Movie.prototype.getDetails = function (movies) {
            var self = this;

            return $http.post(api, movies).then(function (response) {
                var movies = [];

                for (var i = 0; i < response.data.length; i++) {
                    movies.push(new Movie(response.data[i]));
                }

                return movies;
            },
            function (err) {
                throw err.data;
            });
        };

        Movie.prototype.getURLTitle = function () {
            var self = this;

            return self.title.toLowerCase()
                .replace(/ /g, '-')
                .replace(/---/g, '-')
                .replace(/--/g, '-')
                .replace(/:/g, '');
        }

        return Movie;
    }
]);