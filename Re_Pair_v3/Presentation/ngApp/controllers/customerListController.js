var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var CustomerListController = (function () {
            function CustomerListController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('api/orders/')
                    .then(function (response) {
                    _this.orders = response.data;
                });
            }
            CustomerListController.prototype.findCustomerByUserName = function (customerUserName) {
                var _this = this;
                this.$http.get("api/customers/search/" + customerUserName + "/")
                    .then(function (response) {
                    _this.customerUser = response.data;
                });
            };
            return CustomerListController;
        })();
        Controllers.CustomerListController = CustomerListController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=customerListController.js.map