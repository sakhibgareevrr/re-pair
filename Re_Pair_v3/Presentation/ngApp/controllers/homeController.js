var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController($location) {
                this.bussLoginWindow = 1;
                this.custLoginWindow = 1;
                this.$location = $location;
            }
            HomeController.prototype.cancelBussLogin = function () {
                this.bussLoginWindow = 1;
            };
            ;
            HomeController.prototype.cancelCustLogin = function () {
                this.custLoginWindow = 1;
            };
            ;
            HomeController.prototype.enterBussLogin = function () {
                this.bussLoginWindow = 2;
            };
            ;
            HomeController.prototype.enterCustLogin = function () {
                this.custLoginWindow = 2;
            };
            ;
            HomeController.prototype.gotoCustReg = function () {
                this.$location.path('/customerregistration');
            };
            return HomeController;
        })();
        Controllers.HomeController = HomeController;
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=homeController.js.map