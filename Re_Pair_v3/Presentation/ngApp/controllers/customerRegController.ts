namespace Re_Pair_v3.Controllers {

    import CustomerUser = Re_Pair_v3.Models.CustomerUser;

    export class CreateCustomerUserController {

        public newCustomerUser: any;

        public validationErrors;

        private $http;

        constructor($http) {
            this.$http = $http;
        }
        
        public addCustomerUser() {
            this.$http.post('/api/customers/register', this.newCustomerUser)
                .then((response) => {
                    this.newCustomerUser = null;
                })
                .catch((response) => {
                    this.validationErrors = [];

                    let modelState = response.data.modelState;
                    for (let error in modelState) {
                        this.validationErrors = this.validationErrors.concat(modelState[error]);
                    }
                });

        }


    }

}