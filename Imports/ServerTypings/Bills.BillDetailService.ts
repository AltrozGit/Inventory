namespace Indotalent.Bills {
    export namespace BillDetailService {
        export const baseUrl = 'Bills/BillDetail';

        export declare function Create(request: Serenity.SaveRequest<BillDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BillDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BillDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BillDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckBillPaymentGenerated(request: BillDetailIsBillPaymentGeneratedRequest, onSuccess?: (response: BillDetailIsBillPaymentGeneratedResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetQuantityOfBillCreated(request: Web.Modules.Bills.BillDetail.RequestHandlers.BillDetailGetQuantityOfBillCreatedRequest, onSuccess?: (response: Web.Modules.Bills.BillDetail.RequestHandlers.BillDetailGetQuantityOfBillCreatedResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Bills/BillDetail/Create",
            Update = "Bills/BillDetail/Update",
            Delete = "Bills/BillDetail/Delete",
            Retrieve = "Bills/BillDetail/Retrieve",
            List = "Bills/BillDetail/List",
            CheckBillPaymentGenerated = "Bills/BillDetail/CheckBillPaymentGenerated",
            GetQuantityOfBillCreated = "Bills/BillDetail/GetQuantityOfBillCreated"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'CheckBillPaymentGenerated', 
            'GetQuantityOfBillCreated'
        ].forEach(x => {
            (<any>BillDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
