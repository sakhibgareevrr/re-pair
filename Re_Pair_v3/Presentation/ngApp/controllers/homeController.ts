namespace Re_Pair_v3.Controllers {

    export class HomeController {

        public bussLoginWindow: number;
        public custLoginWindow: number;
        private $location;

        constructor($location) {
            this.bussLoginWindow = 1;
            this.custLoginWindow = 1;
            this.$location = $location;
        }

        public cancelBussLogin() {
            this.bussLoginWindow = 1;
        };

        public cancelCustLogin() {
            this.custLoginWindow = 1;
        };
        public enterBussLogin() {

            this.bussLoginWindow = 2;
        };
        public enterCustLogin() {

            this.custLoginWindow = 2;
        };
        public gotoCustReg() {
            this.$location.path('/customerregistration');
        }
    }


}