namespace Re_Pair_v3.Service {
    
    export class DataService {

        public get businessUserName() {
            return this.$window.localStorage.getItem('businessUserName');

        }

        public set businessUserName(value) {
            this.$window.localStorage.setItem('businessUserName', value);
        }

        constructor(
            private $window
        ) { }

    }
    
    angular.module("Re_Pair_v3").service("data",DataService)

}