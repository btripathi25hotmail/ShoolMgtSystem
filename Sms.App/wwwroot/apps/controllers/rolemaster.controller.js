(function () {
    'use strict';
    smsApp.controller('rolemasterController',
        ['$scope', '$window', 'roleService', function ($scope, $window, roleService) {
            $scope.roleId = 0;
            $scope.roleName = '';
            $scope.createdBy = '';
            $scope.isActive = false;
            $scope.isNoRecordFound = false;
            $scope.roles = [];
            $scope.showCreateLayout = true;
            $scope.showEditLayout = false;
            $scope.showListLayout = true;
            $scope.role = {};
            $scope.validationErrors = [];

            $scope.roleModel = {
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

            $scope.showDeleteModal = (roleId) => {
                console.log(roleId);
                $scope.roleId = roleId;
                $("#roleDeleteModal").modal('show');
            };

            $scope.createRole = (roleModel) => {
                $scope.validationErrors = [];
                console.log(roleModel);
                if (roleModel === undefined || roleModel.roleName === "") {
                    $scope.validationErrors.push("Enter role name.");
                }
                if ($scope.validationErrors.length > 0) {
                    $scope.$parent.validationError($scope.validationErrors);
                    return;
                }

                roleService.createRole(roleModel).then((response) => {
                    console.log(response);
                    if (response.data != undefined || response.data !== null) {
                        console.log(response.data);
                        alert(response.data.message);
                        $scope.getRoles();
                    } else {
                        alert(response.data.message);
                    }
                });
            };

            $scope.updateRole = (roleModel) => {
                console.log(roleModel);
                if (roleModel === undefined || roleModel.roleName === "") {
                    $("#validationModal").modal('show');
                    return;
                }
                else {
                    $scope.showCreateLayout = true;
                    $scope.showEditLayout = false;
                    $scope.showListLayout = true;
                    $window.scrollTo(0, angular.element('createDiv').offsetTop);
                }
            };

            $scope.cancel = (roleModel) => {
                roleModel = {};
                $scope.rolneName = '';
                $scope.showCreateLayout = true;
                $scope.showEditLayout = false;
                $scope.showListLayout = true;
            };

            $scope.showEditDiv = (role) => {
                $scope.role = role;
                $scope.showCreateLayout = false;
                $scope.showEditLayout = true;
                $scope.showListLayout = false;
            }


        }])
})();
