var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Models;
    (function (Models) {
        var BusinessUser = (function () {
            function BusinessUser(id, userName, companyName, serviceCategory, description, orders, userAddresses) {
                this.id = id;
                this.userName = userName;
                this.companyName = companyName;
                this.serviceCategory = serviceCategory;
                this.description = description;
                this.orders = orders;
                this.userAddresses = userAddresses;
            }
            return BusinessUser;
        })();
        Models.BusinessUser = BusinessUser;
    })(Models = Re_Pair_v3.Models || (Re_Pair_v3.Models = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=BusinessUser.js.map