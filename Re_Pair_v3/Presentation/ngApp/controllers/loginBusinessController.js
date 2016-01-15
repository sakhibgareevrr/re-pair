var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var LoginBusinessController = (function () {
            function LoginBusinessController($http, $window, $location) {
                this.$http = $http;
                this.$window = $window;
                this.$location = $location;
            }
            LoginBusinessController.prototype.loginBusiness = function () {
                var _this = this;
                var data = "grant_type=password&username=" + this.username + "&password=" + this.password;
                //let data = `email=${this.email}&password=${}&confirmPassword=${}`
                //$http.post('/api/customers/register', data, ...headers
                this.$http.post('/token', data, {
                    headers: { 'Content-type': 'application/x-www-form-urlencoded' }
                })
                    .then(function (response) {
                    _this.$window.localStorage.setItem('token', response.data['access_token']);
                    _this.$location.path('/customers');
                })
                    .catch(function (response) {
                    _this.loginMessage = 'invalid username or password';
                });
            };
            LoginBusinessController.prototype.logoutBusiness = function () {
                this.$window.localStorage.removeItem('token');
                this.$location.path('/');
            };
            LoginBusinessController.prototype.isLoggedInBusiness = function () {
                return this.$window.localStorage.getItem('token');
            };
            return LoginBusinessController;
        })();
        Controllers.LoginBusinessController = LoginBusinessController;
        angular.module("Re_Pair_v3").controller("authBusinessController", Controllers.LoginController);
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
