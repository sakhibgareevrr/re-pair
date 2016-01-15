/// <reference path="useraddress.ts" />
namespace Re_Pair_v3.Models {

    import UserAddress = Re_Pair_v3.Models.UserAddress;

    export class CustomerUser {

        constructor(

            public id: string,

            public email: string,

            public userName: string,

            public orders: Order[],
            
            public userAddresses: UserAddress[]) { }
    }
}
