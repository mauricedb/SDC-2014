(function () {

    var module = angular.module('demoApp', []);

    module.controller('demoCtrl', function ($scope) {
        $scope.model = {
            firstName: 'Maurice',
            lastName: 'de Beijer'
        }
    })

}());