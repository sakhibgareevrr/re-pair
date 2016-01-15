var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var CreateCustomerUserController = (function () {
            function CreateCustomerUserController($http) {
                this.$http = $http;
            }
            CreateCustomerUserController.prototype.addCustomerUser = function () {
                var _this = this;
                this.$http.post('/api/customers/register', this.newCustomerUser)
                    .then(function (response) {
                    _this.newCustomerUser = null;
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            return CreateCustomerUserController;
        })();
        Controllers.CreateCustomerUserController = CreateCustomerUserController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=customerRegController.js.map