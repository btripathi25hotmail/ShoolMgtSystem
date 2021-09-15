(function () {
    'use strict';
    smsApp.directive('ngEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.ngEnter, { 'event': event });
                    });

                    event.preventDefault();
                }
            });
        };
    });
})();


(function () {
    'use strict';
    smsApp.directive('convertToNumber', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$parsers.push(function (val) {
                    return parseInt(val, 10);
                });
                ngModel.$formatters.push(function (val) {
                    return '' + val;
                });
            }
        };
    });
})();

// prevent white space
(function () {
    'use strict';
    smsApp.directive('disallowSpaces', function () {
        return {
            restrict: 'A',

            link: function ($scope, $element) {
                $element.bind('input', function () {
                    $(this).val($(this).val().replace(/ /g, ''));
                });
            }
        };
    });
}());