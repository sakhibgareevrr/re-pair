namespace Re_Pair_v3.Controllers {

    import BusinessUser = Re_Pair_v3.Models.BusinessUser;

    import CustomerUser = Re_Pair_v3.Models.CustomerUser;

    export class LoginController {

        public businessusername: string;

        public customerusername: string;

        public password: string;

        public loginMessage: string;

        public businessUser: BusinessUser;

        public customerUser: CustomerUser;

        constructor(private $http, private $window, private $location) {

        }




        public loginCustomer() {

            this.$http.get(`api/customers/search/${this.customerusername}/`)
                .then((response) => {
                    this.customerUser = response.data;
                    if ((this.customerUser !== null) && (this.customerusername == this.customerUser.userName)) {

                        let data = `grant_type=password&username=${this.customerusername}&password=${this.password}`;

                        //let data = `email=${this.email}&password=${}&confirmPassword=${}`

                        //$http.post('/api/customers/register', data, ...headers

                        this.$http.post('/token', data, {
                            headers: { 'Content-type': 'application/x-www-form-urlencoded' }
                        })
                            .then((response) => {
                                this.$window.localStorage.setItem('token', response.data['access_token']);

                                this.$location.path('/businesses');

                            })
                            .catch((response) => {
                                this.loginMessage = 'invalid username or password';
                            });

                    }
                    else {
                        this.loginMessage = 'invalid username or password';
                    }
                });

        }

        public loginBusiness() {

            this.$http.get(`api/businesses/search/${this.businessusername}/`)
                .then((response) => {
                    this.businessUser = response.data;
                    if ((this.businessUser !== null) && (this.businessusername == this.businessUser.userName)) {

                        let data = `grant_type=password&username=${this.businessusername}&password=${this.password}`;

                         this.$http.post('/token', data, {
                            headers: { 'Content-type': 'application/x-www-form-urlencoded' }
                        })
                            .then((response) => {
                                this.$window.localStorage.setItem('token', response.data['access_token']);
                                this.$location.path('/customers');
                            })
                            .catch((response) => {
                                this.loginMessage = 'invalid username or password';
                            });
                    }

                    else {
                        this.loginMessage = 'invalid username or password';
                    }
                });
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
            this.$location.path('/');
            this.businessusername = '';
            this.customerusername = '';
            this.password = '';
        }

        public isLoggedIn() {
            return this.$window.localStorage.getItem('token');
        }



        public gotoHome() {
            this.$location.path('/');
        }


    }
    angular.module("Re_Pair_v3").controller("authController", LoginController);

}