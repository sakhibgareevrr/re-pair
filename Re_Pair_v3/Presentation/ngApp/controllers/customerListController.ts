namespace Re_Pair_v3.Controllers {

    import CustomerUser = Re_Pair_v3.Models.CustomerUser;

    import Order = Re_Pair_v3.Models.Order;

    export class CustomerListController {

        public customerUser: CustomerUser;

        public orders: Order[];

        constructor(public $http) {
            
            $http.get('api/orders/')
                .then((response) => {
                    this.orders = response.data;

                });
        }

        public findCustomerByUserName(customerUserName: string)
        {
            this.$http.get(`api/customers/search/${customerUserName}/`)
                .then((response) => {
                    this.customerUser = response.data;
                });


        }

    }
}
