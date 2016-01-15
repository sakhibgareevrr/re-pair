var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var OrderListController = (function () {
            function OrderListController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('api/orders')
                    .then(function (response) {
                    _this.orders = response.data;
                });
                $http.get('api/useraddress')
                    .then(function (response) {
                    _this.userAddresses = response.data;
                });
            }
            return OrderListController;
        })();
        Controllers.OrderListController = OrderListController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=orderListController.js.map