(function () {
    'use strict';
    smsApp.factory('roleService', ['$http', '$q', function ($http, $q) {
        return {
            getRoles: () => {
                var deferred = $q.defer();
                return $http.get("/userrole/GetRoles").then(deferred.resolve).catch(deferred.reject), deferred.promise;
            },
            createRole: (roleModel) => {
                var deferred = $q.defer();
                console.log('service', roleModel);
                return $http.post("/userrole/CreateRole", roleModel).then(deferred.resolve).catch(deferred.reject), deferred.promise;
            }
        };
    }]);
})();