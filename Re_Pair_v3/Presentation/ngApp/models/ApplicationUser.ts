namespace Re_Pair_v3.Models {

    import UserAddress = Re_Pair_v3.Models.UserAddress;

    export class ApplicationUser {

        constructor(

            public id: string,

            public userName: string,

            public userAddresses: UserAddress[]) { }
    }

}