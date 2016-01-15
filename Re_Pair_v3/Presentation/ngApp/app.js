var Re_Pair_v3;
(function (Re_Pair_v3) {
    angular.module("Re_Pair_v3", ['ngRoute']);
    angular.module("Re_Pair_v3").factory('authInterceptor', function ($q, $window, $location) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                var token = $window.localStorage.getItem('token');
                if (token) {
                    config.headers.Authorization = "Bearer " + token;
                }
                return config;
            },
            responseError: function (response) {
                if (response.status === 401) {
                    $location.path('/login');
                }
                return response || $q.when(response);
            }
        };
    });
    angular.module("Re_Pair_v3").config(function ($routeProvider, $httpProvider) {
        $routeProvider
            .when('/', {
            templateUrl: '/presentation/ngApp/views/home.html',
            controller: Re_Pair_v3.Controllers.HomeController,
            controllerAs: 'home'
        })
            .when('/login', {
            templateUrl: '/presentation/ngApp/views/login.html',
            controller: Re_Pair_v3.Controllers.LoginController,
            controllerAs: 'auth'
        })
            .when('/customers', {
            templateUrl: '/presentation/ngApp/views/customers.html',
            controller: Re_Pair_v3.Controllers.CustomerListController,
            controllerAs: 'clc'
        })
            .when('/businessregistration', {
            templateUrl: '/presentation/ngApp/views/businessregistration.html',
            controller: Re_Pair_v3.Controllers.CreateBusinessUserController,
            controllerAs: 'brc'
        })
            .when('/customerregistration', {
            templateUrl: '/presentation/ngApp/views/customerregistration.html',
            controller: Re_Pair_v3.Controllers.CreateCustomerUserController,
            controllerAs: 'crc'
        })
            .when('/createneworder/', {
            templateUrl: '/presentation/ngApp/views/neworder.html',
            controller: Re_Pair_v3.Controllers.CreateOrderController,
            controllerAs: 'coc'
        })
            .when('/businesses', {
            templateUrl: '/presentation/ngApp/views/businesses.html',
            controller: Re_Pair_v3.Controllers.BusinessListController,
            controllerAs: 'blc'
        })
            .when('/update/:id', {
            templateUrl: '/presentation/ngApp/views/update.html',
            controller: Re_Pair_v3.Controllers.UpdateController,
            controllerAs: 'uc'
        });
        $httpProvider.interceptors.push('authInterceptor');
    });
})(Re_Pair_v3 || (Re_Pair_v3 = {}));
//# sourceMappingURL=app.js.map