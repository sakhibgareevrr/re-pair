var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var CreateOrderController = (function () {
            function CreateOrderController($http, $location, data) {
                this.$location = $location;
                this.$http = $http;
                this.businessUserData = data;
            }
            CreateOrderController.prototype.createNewOrder = function () {
                var _this = this;
                this.newOrder.businessUserName = this.businessUserData.businessUserName;
                console.log(this.newOrder.businessUserName);
                this.$http.post('/api/orders', this.newOrder)
                    .then(function (response) {
                    _this.newOrder = null;
                    //this.businessUserData.businessUserName = response.data['businessUserName'];
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
            return CreateOrderController;
        })();
        Controllers.CreateOrderController = CreateOrderController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=createOrderController.js.map