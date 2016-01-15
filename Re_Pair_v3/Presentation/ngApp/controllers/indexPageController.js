var Re_Pair_v3;
(function (Re_Pair_v3) {
    var IndexPageController = (function () {
        function IndexPageController($location) {
            this.$location = $location;
        }
        IndexPageController.prototype.gotoHome = function () {
            this.$location.path('#/');
        };
        return IndexPageController;
    })();
    Re_Pair_v3.IndexPageController = IndexPageController;
    angular.module('Re_Pair_v3').controller("IndexPageController", IndexPageController);
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=indexPageController.js.map