namespace Re_Pair_v3.Controllers {

    import BusinessUser = Re_Pair_v3.Models.BusinessUser;

    export class CreateBusinessUserController {

        public newBusinessUser: any;

        public validationErrors;

        private $http;

        constructor($http) {
            this.$http = $http;
        }

        public addBusinessUser() {
            this.$http.post('/api/businesses/register', this.newBusinessUser)
                .then((response) => {
                    this.newBusinessUser = null;
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