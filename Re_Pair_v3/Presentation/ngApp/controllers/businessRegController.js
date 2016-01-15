var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var CreateBusinessUserController = (function () {
            function CreateBusinessUserController($http) {
                this.$http = $http;
            }
            CreateBusinessUserController.prototype.addBusinessUser = function () {
                var _this = this;
                this.$http.post('/api/businesses/register', this.newBusinessUser)
                    .then(function (response) {
                    _this.newBusinessUser = null;
                })
                    .catch(function (response) {
                    _this.validationErrors = [];
                    var modelState = response.data.modelState;
                    for (var error in modelState) {
                        _this.validationErrors = _this.validationErrors.concat(modelState[error]);
                    }
                });
            };
            return CreateBusinessUserController;
        })();
        Controllers.CreateBusinessUserController = CreateBusinessUserController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=businessRegController.js.map