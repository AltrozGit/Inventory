namespace Indotalent.Web.Modules.Purchase.PurchaseOrder {
    export class RequestContext {
        static sharedData: any = {};

        static set(key: string, value: any) {
            this.sharedData[key] = value;
        }

        static get(key: string) {
            return this.sharedData[key];
        }

     

        
    }
}
