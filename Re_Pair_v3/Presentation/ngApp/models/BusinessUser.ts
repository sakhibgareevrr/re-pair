namespace Re_Pair_v3.Models {

    import UserAddress = Re_Pair_v3.Models.UserAddress;

    export class BusinessUser {
        constructor(

            public id: string,

            public userName: string,

            public companyName: string,

            public serviceCategory: string,

            public description: string,

            public orders: Order[],

            public userAddresses: UserAddress[]) { }

    }
}
