(function () {
    'use strict';
    smsApp.controller("siteController",
        ['$scope',
            function ($scope) {
                $scope.appTitle = 'School Management System';
                $scope.validationTitle = 'Validation Error!!';
                $scope.errors = [];
                $scope.validationError = (errorList) => {
                    $scope.errors = [];
                    $scope.errors = errorList;
                    $("#exampleModalCenter").modal("show");
                };

            }]);
}());