/// <reference path="useraddress.ts" />
var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Models;
    (function (Models) {
        var CustomerUser = (function () {
            function CustomerUser(id, email, userName, orders, userAddresses) {
                this.id = id;
                this.email = email;
                this.userName = userName;
                this.orders = orders;
                this.userAddresses = userAddresses;
            }
            return CustomerUser;
        })();
        Models.CustomerUser = CustomerUser;
    })(Models = Re_Pair_v3.Models || (Re_Pair_v3.Models = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=CustomerUser.js.map