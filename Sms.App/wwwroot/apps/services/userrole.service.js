(function () {
    'use strict';
    smsApp.factory('roleService', ['$http', '$q', function ($http, $q) {
        return {
            validate: (loginModel) => {
                var deferred = $q.defer();
                return $http.post("http://localhost:5287" + "validateuser", loginModel).then(deferred.resolve).catch(deferred.reject), deferred.promise;
            },
            resetPassword: (resetModel) => {
                var deferred = $q.defer();
                return $http.post("http://localhost:5287" + "resetpassword", resetModel).then(deferred.resolve).catch(deferred.reject), deferred.promise;
            },
            getRoles: () => {
                var deferred = $q.defer();
                return $http.get("/userrole/GetRoles").then(deferred.resolve).catch(deferred.reject), deferred.promise;
            }
        };
    }]);
})();