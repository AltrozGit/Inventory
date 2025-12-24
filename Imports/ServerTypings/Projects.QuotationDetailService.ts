namespace Indotalent.Projects {
    export namespace QuotationDetailService {
        export const baseUrl = 'Projects/QuotationDetail';

        export declare function Create(request: Serenity.SaveRequest<QuotationDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<QuotationDetailRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<QuotationDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<QuotationDetailRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckTenantStateId(request: Sales.SalesOrderDetailTenantStateHandlerRequest, onSuccess?: (response: Sales.SalesOrderDetailTenantStateHandlerResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Projects/QuotationDetail/Create",
            Update = "Projects/QuotationDetail/Update",
            Delete = "Projects/QuotationDetail/Delete",
            Retrieve = "Projects/QuotationDetail/Retrieve",
            List = "Projects/QuotationDetail/List",
            CheckTenantStateId = "Projects/QuotationDetail/CheckTenantStateId"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'CheckTenantStateId'
        ].forEach(x => {
            (<any>QuotationDetailService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
