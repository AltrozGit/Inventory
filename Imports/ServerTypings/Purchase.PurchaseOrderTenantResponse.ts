namespace Indotalent.Purchase {
    export interface PurchaseOrderTenantResponse extends Serenity.ServiceResponse {
        Name?: string;
        Street?: string;
        City?: string;
        ZipCode?: string;
        StateId?: string;
        Phone?: string;
        Email?: string;
    }
}
