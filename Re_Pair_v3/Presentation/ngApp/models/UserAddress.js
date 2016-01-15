var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Models;
    (function (Models) {
        var UserAddress = (function () {
            function UserAddress(id, 
                //public applicationUser: ApplicationUser,
                firstName, lastName, phone, addressLine1, addressLine2, city, state, zipcode) {
                this.id = id;
                this.firstName = firstName;
                this.lastName = lastName;
                this.phone = phone;
                this.addressLine1 = addressLine1;
                this.addressLine2 = addressLine2;
                this.city = city;
                this.state = state;
                this.zipcode = zipcode;
            }
            return UserAddress;
        })();
        Models.UserAddress = UserAddress;
    })(Models = Re_Pair_v3.Models || (Re_Pair_v3.Models = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=useraddress.js.map