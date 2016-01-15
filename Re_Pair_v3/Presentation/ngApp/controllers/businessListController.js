var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var BusinessListController = (function () {
            function BusinessListController($http, $location, data) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                $http.get('api/businesses/')
                    .then(function (response) {
                    _this.businessUsers = response.data;
                });
                $http.get('api/orders/')
                    .then(function (response) {
                    _this.orders = response.data;
                });
                this.businessUserData = data;
            }
            BusinessListController.prototype.setBusinessUserforOrder = function (businessusername) {
                this.businessUserData.businessUserName = businessusername;
                this.$location.path('/createneworder');
                console.log(this.businessUserData.businessUserName);
            };
            ;
            BusinessListController.prototype.goToUpdate = function (id) {
                this.$location.path("/update/" + id);
            };
            return BusinessListController;
        })();
        Controllers.BusinessListController = BusinessListController;
        angular.module("Re_Pair_v3").controller("blcController", BusinessListController);
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=businessListController.js.map