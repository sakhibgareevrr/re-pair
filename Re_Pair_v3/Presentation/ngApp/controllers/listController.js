var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var ListController = (function () {
            function ListController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('api/orders')
                    .then(function (response) {
                    _this.orders = response.data;
                });
            }
            return ListController;
        })();
        Controllers.ListController = ListController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
