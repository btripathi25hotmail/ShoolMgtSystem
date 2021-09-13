(function () {
    'use strict';
    smsApp.controller('rolemasterController',
        ['$scope', 'roleService', function ($scope, roleService) {
            $scope.roleId = 0;
            $scope.roleName = '';
            $scope.createdBy = '';
            $scope.isActive = false;
            $scope.isNoRecordFound = false;
            $scope.roles = [];

            $scope.RoleModel = {
                roleId: $scope.roleId,
                roleName: $scope.roleName,
                createdBy: $scope.createdBy,
                isActive: $scope.isActive
            };

            $scope.getRoles = () => {
                roleService.getRoles().then((response) => {
                    if (response.data.length > 0) {
                        $scope.roles = response.data;
                        $scope.isNoRecordFound = false;
                    }
                    else {
                        $scope.isNoRecordFound = true;
                    }
                });
            };

            $scope.deleteRole = (roleId) => {
                console.log(roleId);
                if (confirm("Do you want to delete role ?")) {
                    alert('Deleted');
                }
            };



        }])
})();
