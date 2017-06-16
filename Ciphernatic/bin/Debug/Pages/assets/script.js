
/// Controller Logic:
(function () {

    //define module
    var app = angular.module("ciphernaticsViewer", []);

    //define controller
    var MainController = function ($scope, $http) {
        
        var onComplete = function(response) {
            $scope.output = response;

        }

        var onRepos = function(response) {
            $scope.repos = response.data;
        }

        var onError = function(reason) {
            $scope.error = "Something went wrong!";
        }

        $scope.hash = function (inputvalue) {
            $http.get("http://localhost:8888/api/Ciphernatic/GetHashList?value=" + inputvalue).then(onRepos, onError);
        }

     
        
    }

    //register components
    app.controller("MainController", MainController);
}());