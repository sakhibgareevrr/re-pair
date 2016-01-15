namespace Re_Pair_v3.Controllers {

    import BusinessUser = Re_Pair_v3.Models.BusinessUser;

    import Order = Re_Pair_v3.Models.Order;

    import DataService = Re_Pair_v3.Service.DataService;

    export class BusinessListController {

        public businessUsers: BusinessUser[];

        public orders: Order[];

        private businessUserData: DataService;

        constructor(public $http, private $location, data) {
            $http.get('api/businesses/')
                .then((response) => {
                    this.businessUsers = response.data;

                });
            $http.get('api/orders/')
                .then((response) => {
                    this.orders = response.data;

                });
            this.businessUserData = data;
        }

        public setBusinessUserforOrder(businessusername: string) {
            this.businessUserData.businessUserName = businessusername;
            this.$location.path('/createneworder');
            console.log(this.businessUserData.businessUserName);
        };

        public goToUpdate(id: number) {
            this.$location.path(`/update/${id}`);
        }

    }

    angular.module("Re_Pair_v3").controller("blcController", BusinessListController);

}