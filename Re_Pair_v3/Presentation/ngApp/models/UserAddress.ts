namespace Re_Pair_v3.Models {

    import ApplicationUser = Re_Pair_v3.Models.ApplicationUser;

    export class UserAddress {

        constructor(

            public id: string,
            
            //public applicationUser: ApplicationUser,

            public firstName: string,

            public lastName: string,

            public phone: string,

            public addressLine1: string,

            public addressLine2: string,

            public city: string,

            public state: string,

            public zipcode: number

        ) { }

    }


}