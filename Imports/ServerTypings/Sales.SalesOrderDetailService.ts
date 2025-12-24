namespace Indotalent.Sales {
    export namespace SalesOrderDetailService {
        export const baseUrl = 'Sales/SalesOrderDetail';

        export declare function Create(request: Serenity.SaveRequest<SalesOrderDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<SalesOrderDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SalesOrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SalesOrderDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckInvoiceGenerated(request: SalesOrderDetailIsInvoiceGeneratedRequest, onSuccess?: (response: SalesOrderDetailIsInvoiceGeneratedResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckTenantStateId(request: SalesOrderDetailTenantStateHandlerRequest, onSuccess?: (response: SalesOrderDetailTenantStateHandlerResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Sales/SalesOrderDetail/Create",
            Update = "Sales/SalesOrderDetail/Update",
            Delete = "Sales/SalesOrderDetail/Delete",
            Retrieve = "Sales/SalesOrderDetail/Retrieve",
            List = "Sales/SalesOrderDetail/List",
            CheckInvoiceGenerated = "Sales/SalesOrderDetail/CheckInvoiceGenerated",
            CheckTenantStateId = "Sales/SalesOrderDetail/CheckTenantStateId"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'CheckInvoiceGenerated', 
            'CheckTenantStateId'
        ].forEach(x => {
            (<any>SalesOrderDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
