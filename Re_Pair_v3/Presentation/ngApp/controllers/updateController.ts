namespace Re_Pair_v3.Controllers {

    import DataService = Re_Pair_v3.Service.DataService;
    import Order = Re_Pair_v3.Models.Order;

    export class UpdateController {

        public order: Order;

        public validationErrors;

        private businessUserData: DataService;

        constructor(private $http, private $location, private $routeParams, data) {
            $http.get(`/api/orders/${$routeParams['id']}`)
                .then((response) => {
                    this.order = response.data;
                    this.businessUserData = data;
                });
        }

        public updateOrder() {

            this.$http.post(`/api/orders/${this.order.id}`, this.order)
                .then((response) => {
                    this.order = null;
                    
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