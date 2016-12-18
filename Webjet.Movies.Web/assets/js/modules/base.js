/* 
namespace:  Webjet.Movies.Web
data: 13/12/2016
objective: the representation of a base entity and some utils modules
dev: adriano.galesso
*/

const environment = "http://localhost:57686/api/";

var baseModule = angular.module('baseModule', []);

baseModule.factory('Base', [function () {

    var Base = function (base) {
        self = this;

        if (!base) {
            base = {};
        }

        this.id = base.id;
    };

    Base.prototype.formatStringDate = function (date) {
        return date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    };

    return Base;
}]);

var objectModule = angular.module('objectModule', []);

objectModule.factory('ObjectUtils', function () {
    return {
        bind: function (oldObj, newObj) {
            for (var key in newObj) {
                if (oldObj.hasOwnProperty(key)) {
                    oldObj[key] = newObj[key];
                }
            }

            return oldObj;
        }
    };
});