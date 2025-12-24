
namespace Indotalent.Purchase {

    @Serenity.Decorators.registerClass()
    export class VendorGrid extends Serenity.EntityGrid<VendorRow, any> {
        getSelectedKeys: any;
        protected getColumnsKey() { return VendorColumns.columnsKey; }
        protected getDialogType() { return VendorDialog; }
        protected getIdProperty() { return VendorRow.idProperty; }
        protected getInsertPermission() { return VendorRow.insertPermission; }
        protected getLocalTextPrefix() { return VendorRow.localTextPrefix; }
        protected getService() { return VendorService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getColumns() {
            let columns = super.getColumns();

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != VendorRow.Fields.TenantName && x.field != VendorRow.Fields.Id);
            }
            /* Display Address field (concatenation of Street, City, State and Phone):(Mayuri date:24/07/2024)*/
            columns.splice(1, 0, {
                id: '',
                field: '',
                name: 'Address',
                format: ctx => {
                    var item = ctx.item;
                    let addressParts = [];
                    if (item[VendorRow.Fields.Street]) addressParts.push(item[VendorRow.Fields.Street]);
                    if (item[VendorRow.Fields.City]) addressParts.push(item[VendorRow.Fields.City]);
                    if (item[VendorRow.Fields.ZipCode]) addressParts.push(item[VendorRow.Fields.ZipCode]);
                    if (item[VendorRow.Fields.StateName]) addressParts.push(item[VendorRow.Fields.StateName]);
                    if (item[VendorRow.Fields.CountryName]) addressParts.push(item[VendorRow.Fields.CountryName]);


                    return addressParts.join(', ');
                },
                width: 350,
                minWidth: 300,
                maxWidth: 350
            });

            return columns;
        }


        protected getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serenity.Extensions.ExcelExportHelper.createToolButton({
                grid: this,
                service: this.getService() + '/ListExcel',
                onViewSubmit: () => this.onViewSubmit(),
                separator: true
            }));

            buttons.push(Serenity.Extensions.PdfExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit()
            }));

            //buttons.push(({
            //    title: 'Send Message',
            //    cssClass: 'send-message-button',
            //    onClick: () => this.onSendMessageButtonClick()
            //}));


            return buttons;
        }

        //private onSendMessageButtonClick() {
        //    // Retrieve selected rows (or single row if needed)
        //    let selectedRows = this.getSelectedKeys();
        //    if (selectedRows.length === 0) {
        //        Q.notifyError('Please select a record to send the message.');
        //        return;
        //    }

        //    // Call your API endpoint to send the message
        //    this.sendMessage(selectedRows);
        //}

        //private sendMessage(selectedRows: number[]) {
        //    // Example: Use Ajax to call your API
        //    $.ajax({
        //        url: '/your-api/send-message',
        //        type: 'POST',
        //        contentType: 'application/json',
        //        data: JSON.stringify({
        //            phoneNumber: '1234567890', // Replace with dynamic phone number from selected row
        //            message: 'Hello, this is a test message!' // Replace with dynamic message
        //        }),
        //        success: (response) => {
        //            Q.notifySuccess('Message sent successfully!');
        //        },
        //        error: (error) => {
        //            Q.notifyError('Failed to send message.');
        //        }

    }
}
    

    
//columns.splice(1, 0, {
//    id: '',
//    field: null,
//    name: 'Address',
//    format: ctx => {
//        var item = ctx.item;

//        return item[VendorRow.Fields.Street] + ', ' + item[VendorRow.Fields.City] + ', ' + item[VendorRow.Fields.State] + ', ' + item[VendorRow.Fields.Phone];
//    },
//    width: 400,
//    minWidth: 300,
//    maxWidth: 400
//});
