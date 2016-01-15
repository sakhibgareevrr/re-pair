var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Service;
    (function (Service) {
        var DataService = (function () {
            function DataService($window) {
                this.$window = $window;
            }
            Object.defineProperty(DataService.prototype, "businessUserForOrder", {
                get: function () {
                    return this.$window.localStorage.getItem('businessUserForOrder');
                },
                set: function (value) {
                    this.$window.localStorage.setItem('businessUserForOrder', value);
                },
                enumerable: true,
                configurable: true
            });
            return DataService;
        })();
        Service.DataService = DataService;
        angular.module("Re_Pair_v3").service("data", DataService);
    })(Service = Re_Pair_v3.Service || (Re_Pair_v3.Service = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
