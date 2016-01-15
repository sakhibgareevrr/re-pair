var Re_Pair_v3;
(function (Re_Pair_v3) {
    var Controllers;
    (function (Controllers) {
        var LoginController = (function () {
            function LoginController($http, $window, $location) {
                this.$http = $http;
                this.$window = $window;
                this.$location = $location;
            }
            LoginController.prototype.loginCustomer = function () {
                var _this = this;
                this.$http.get("api/customers/search/" + this.customerusername + "/")
                    .then(function (response) {
                    _this.customerUser = response.data;
                    if ((_this.customerUser !== null) && (_this.customerusername == _this.customerUser.userName)) {
                        var data = "grant_type=password&username=" + _this.customerusername + "&password=" + _this.password;
                        //let data = `email=${this.email}&password=${}&confirmPassword=${}`
                        //$http.post('/api/customers/register', data, ...headers
                        _this.$http.post('/token', data, {
                            headers: { 'Content-type': 'application/x-www-form-urlencoded' }
                        })
                            .then(function (response) {
                            _this.$window.localStorage.setItem('token', response.data['access_token']);
                            _this.$location.path('/businesses');
                        })
                            .catch(function (response) {
                            _this.loginMessage = 'invalid username or password';
                        });
                    }
                    else {
                        _this.loginMessage = 'invalid username or password';
                    }
                });
            };
            LoginController.prototype.loginBusiness = function () {
                var _this = this;
                this.$http.get("api/businesses/search/" + this.businessusername + "/")
                    .then(function (response) {
                    _this.businessUser = response.data;
                    if ((_this.businessUser !== null) && (_this.businessusername == _this.businessUser.userName)) {
                        var data = "grant_type=password&username=" + _this.businessusername + "&password=" + _this.password;
                        _this.$http.post('/token', data, {
                            headers: { 'Content-type': 'application/x-www-form-urlencoded' }
                        })
                            .then(function (response) {
                            _this.$window.localStorage.setItem('token', response.data['access_token']);
                            _this.$location.path('/customers');
                        })
                            .catch(function (response) {
                            _this.loginMessage = 'invalid username or password';
                        });
                    }
                    else {
                        _this.loginMessage = 'invalid username or password';
                    }
                });
            };
            LoginController.prototype.logout = function () {
                this.$window.localStorage.removeItem('token');
                this.$location.path('/');
                this.businessusername = '';
                this.customerusername = '';
                this.password = '';
            };
            LoginController.prototype.isLoggedIn = function () {
                return this.$window.localStorage.getItem('token');
            };
            LoginController.prototype.gotoHome = function () {
                this.$location.path('/');
            };
            return LoginController;
        })();
        Controllers.LoginController = LoginController;
        angular.module("Re_Pair_v3").controller("authController", LoginController);
    })(Controllers = Re_Pair_v3.Controllers || (Re_Pair_v3.Controllers = {}));
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=loginController.js.map