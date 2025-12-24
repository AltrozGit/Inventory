namespace Indotalent.Sales {
    export interface SalesDeliveryForm {
        Number: Serenity.StringEditor;
        DeliveryDate: Serenity.DateEditor;
        Description: Serenity.TextAreaEditor;
        SalesOrderId: Serenity.LookupEditor;
        ShipperId: Serenity.LookupEditor;
        ProjectId: Serenity.LookupEditor;
        WarehouseId: Serenity.LookupEditor;
        LocationId: Serenity.LookupEditor;
        ItemList: SalesDeliveryDetailEditor;
        TotalQtyDelivered: Serenity.DecimalEditor;
    }

    export class SalesDeliveryForm extends Serenity.PrefixedContext {
        static formKey = 'Sales.SalesDelivery';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SalesDeliveryForm.init)  {
                SalesDeliveryForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.LookupEditor;
                var w4 = SalesDeliveryDetailEditor;
                var w5 = s.DecimalEditor;

                Q.initFormType(SalesDeliveryForm, [
                    'Number', w0,
                    'DeliveryDate', w1,
                    'Description', w2,
                    'SalesOrderId', w3,
                    'ShipperId', w3,
                    'ProjectId', w3,
                    'WarehouseId', w3,
                    'LocationId', w3,
                    'ItemList', w4,
                    'TotalQtyDelivered', w5
                ]);
            }
        }
    }
}
