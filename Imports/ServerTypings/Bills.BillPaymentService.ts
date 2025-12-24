namespace Indotalent.Bills {
    export namespace BillPaymentService {
        export const baseUrl = 'Bills/BillPayment';

        export declare function Create(request: Serenity.SaveRequest<BillPaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BillPaymentRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BillPaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BillPaymentRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Currency(request: BillPaymentCurrencyRequest, onSuccess?: (response: BillPaymentCurrencyResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Bills/BillPayment/Create",
            Update = "Bills/BillPayment/Update",
            Delete = "Bills/BillPayment/Delete",
            Retrieve = "Bills/BillPayment/Retrieve",
            List = "Bills/BillPayment/List",
            Currency = "Bills/BillPayment/Currency"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'Currency'
        ].forEach(x => {
            (<any>BillPaymentService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
