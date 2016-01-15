namespace Re_Pair_v3.Controllers {

    import DataService = Re_Pair_v3.Service.DataService;
    import Order = Re_Pair_v3.Models.Order;

    export class CreateOrderController {

        public newOrder: Order;

        public validationErrors;

        private $http;

        private businessUserData: DataService;

        constructor($http, private $location, data) {
            this.$http = $http;
            this.businessUserData = data;
            
            
        }

        public createNewOrder() {
            this.newOrder.businessUserName = this.businessUserData.businessUserName;

            console.log(this.newOrder.businessUserName);
            this.$http.post('/api/orders', this.newOrder)
                .then((response) => {
                    this.newOrder = null;
                    //this.businessUserData.businessUserName = response.data['businessUserName'];
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                })
            this.$location.path('/businesses');
            this.$location.reload();
        }

    }

}