namespace Re_Pair_v3 {

    export class IndexPageController {
        private $location

        constructor($location) {

            this.$location = $location;
        }

        public gotoHome() {
            this.$location.path('#/');
        }

        
    }
    angular.module('Re_Pair_v3').controller("IndexPageController", IndexPageController);

}