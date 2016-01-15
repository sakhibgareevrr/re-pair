var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Models;
    (function (Models) {
        var Order = (function () {
            function Order(id, 
                //public business: BusinessUser,
                //public customer: CustomerUser,
                businessUserName, customerUserName, serviceName, orderDate, completionDate, price, serviceQuality, isApproved, isCompleted) {
                this.id = id;
                this.businessUserName = businessUserName;
                this.customerUserName = customerUserName;
                this.serviceName = serviceName;
                this.orderDate = orderDate;
                this.completionDate = completionDate;
                this.price = price;
                this.serviceQuality = serviceQuality;
                this.isApproved = isApproved;
                this.isCompleted = isCompleted;
            }
            return Order;
        })();
        Models.Order = Order;
    })(Models = Re_Pair_v3.Models || (Re_Pair_v3.Models = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=Order.js.map