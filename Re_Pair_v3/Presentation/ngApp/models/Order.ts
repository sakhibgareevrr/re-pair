namespace Re_Pair_v3.Models {


    import BusinessUser = Re_Pair_v3.Models.BusinessUser;

    import CustomerUser = Re_Pair_v3.Models.CustomerUser;

    export class Order {

        constructor(

            public id: number,

            //public business: BusinessUser,

            //public customer: CustomerUser,

            public businessUserName: string,

            public customerUserName: string,

            public serviceName: string,

            public orderDate: string,

            public completionDate: string,

            public price: number,

            public serviceQuality: number,

            public isApproved: boolean,

            public isCompleted: boolean

        ) { }

    }


}