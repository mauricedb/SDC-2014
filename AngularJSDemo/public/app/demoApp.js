(function () {

    var module = angular.module('demoApp', []);

    module.value('xyz', 42);

    module.controller('demoCtrl', ["$scope", "$http", "xyz",function ($scope, $http, xyz) {
        $scope.people = [];

        $scope.model = {
            firstName: 'Maurice',
            lastName: 'de Beijer'
        };

        $scope.add = function (person) {
            $scope.people.push(angular.copy(person));
        };
    }])

}());