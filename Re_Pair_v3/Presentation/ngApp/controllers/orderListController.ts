namespace Re_Pair_v3.Controllers {

    import Order = Re_Pair_v3.Models.Order;

    import UserAddress = Re_Pair_v3.Models.UserAddress;

    export class OrderListController {

        public orders: Order[];

        public userAddresses: UserAddress[];

        constructor(public $http) {
            $http.get('api/orders')
                .then((response) => {
                    this.orders = response.data;
                });
            $http.get('api/useraddress')
                .then((response) => {
                    this.userAddresses = response.data;
                });

        }

        



    }
}