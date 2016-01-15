var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var UpdateController = (function () {
            function UpdateController($http, $location, $routeParams, data) {
                var _this = this;
                this.$http = $http;
                this.$location = $location;
                this.$routeParams = $routeParams;
                $http.get("/api/orders/" + $routeParams['id'])
                    .then(function (response) {
                    _this.order = response.data;
                    _this.businessUserData = data;
                });
            }
            UpdateController.prototype.updateOrder = function () {
                var _this = this;
                this.$http.post("/api/orders/" + this.order.id, this.order)
                    .then(function (response) {
                    _this.order = null;
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
                this.$location.path('/businesses');
                this.$location.reload();
            };
            return UpdateController;
        })();
        Controllers.UpdateController = UpdateController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=updateController.js.map