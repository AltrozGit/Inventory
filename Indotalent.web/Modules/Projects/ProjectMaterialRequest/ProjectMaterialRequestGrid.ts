namespace Indotalent.Projects {
    
    @Serenity.Decorators.registerClass()
    export class ProjectMaterialRequestGrid extends Serenity.EntityGrid<ProjectMaterialRequestRow, any> {
        protected getColumnsKey() { return ProjectMaterialRequestColumns.columnsKey; }
        protected getDialogType() { return ProjectMaterialRequestDialog; }
        protected getIdProperty() { return ProjectMaterialRequestRow.idProperty; }
        protected getInsertPermission() { return ProjectMaterialRequestRow.insertPermission; }
        protected getLocalTextPrefix() { return ProjectMaterialRequestRow.localTextPrefix; }
        protected getService() { return ProjectMaterialRequestService.baseUrl; }
        public static readonly RequestStatusPending = 1;
        public static readonly RequestStatusApproved = 2;
        public static readonly RequestStatusRejected = 3;
        private Status = ProjectMaterialRequestGrid.RequestStatusPending;



        public static readonly Approved = "Approved";
        public static readonly Rejected = "Rejected";


        constructor(container: JQuery) {
            super(container);
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

            // *** End Authorize permissions ***
            return buttons;
        }
        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            //show amount should be in decimal 
            columns.forEach(col => {
                // List the columns that should have decimal formatting using indexOf
                if (["TotalQtyRequest", "Total"].indexOf(col.field) !== -1) {
                    col.formatter = (row, cell, value, columnDef, dataContext) => {
                        return value !== null && value !== undefined ? value.toFixed(2) : ''; // Format to two decimals
                    };
                    col.cssClass = "text-right"; // This aligns the cell content to the right
                }
            });


            columns.splice(1, 0, {
                id: 'Print Selected',
                field: null,
                name: '',
                format: ctx => '<a class="inline-action print-selected" title="print-selected">' +
                    '<i class="fa fa-file-pdf-o text-red"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            columns.splice(2, 0, {
                field: 'RequestDate',
                name: 'Month - Year',
                width: 100,
                sortable: true,
                format: (ctx) => {
                    const requestItem = ctx.item as ProjectMaterialRequestRow;
                    const date = new Date(requestItem.RequestDate);
                    const options: Intl.DateTimeFormatOptions = { month: 'short', year: 'numeric' };
                    return date.toLocaleDateString('en-US', options).replace(',', ' -');
                }
            });

            if (Q.Authorization.hasPermission("Administration:ProjectApprovalmanagement")) {

                columns.push({
                    id: '',
                    field: null,
                    name: 'Take Action',
                    format: ctx => {
                        var item = ctx.item;

                        if (item.RequestStatus === Indotalent.Web.Modules.Material.Request.RequestStatus.Pending) {
                            return '<a class="inline-action Approve-action" style="color: Green; font-weight: bold; margin-right: 10px;" title="Approve">' +
                                '<i class="fa fa-check-circle text-green"></i>Approve</a>' +
                                '<a class="inline-action Reject-action" style="color: Red; font-weight: bold;" title="Reject">' +
                                '<i class="fa fa-times text-Red"></i>Reject</a>';
                        }
                        else if (item.RequestStatus === Indotalent.Web.Modules.Material.Request.RequestStatus.Approved ||
                            item.RequestStatus === Indotalent.Web.Modules.Material.Request.RequestStatus.Rejected) {
                            return '<a class="inline-action Review-action" style="color: Green; font-weight: bold;" title="Review">' +
                                '<i class="fa fa-check-circle text-green"></i>Review</a>';
                        }

                    },
                    width: 200,
                    minWidth: 200,
                    maxWidth: 200
                });


            }

            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != ProjectMaterialRequestRow.Fields.TenantName && x.field != ProjectMaterialRequestRow.Fields.Id);
            }


            //columns.unshift({
            //    name: `<input type='checkbox' id='select-all' />`,
            //    field: "IsSelected",
            //    format: (ctx) => `<input type='checkbox' class='select-row' data-id='${ctx.item.ProductId}' />`,
            //    width: 50,
            //    sortable: false,
            //    cssClass: "align-center"
            //} as Slick.Column);

            //$(document).on('change', '#select-all',
            //    function () {
            //        const isChecked = $(this).is(':checked');
            //        $('.select-row').prop('checked', isChecked);
            //    });

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            // if user clicks "i" element, e.g. icon
            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('print-selected')) {
                    Serenity.Extensions.ReportHelper.execute({
                        reportKey: 'ProjectMaterialRequestPrint',
                        params: {
                            Id: item.Id
                        }
                    });

                }

            }
            if (target.hasClass('inline-action')) {
                e.preventDefault();

                if (target.hasClass('Approve-action')) {

                    var CurrentAction = ProjectMaterialRequestGrid.Approved;


                    this.ProcessActionRequest(CurrentAction, row);

                }
                if (target.hasClass('Reject-action')) {



                    var CurrentAction = ProjectMaterialRequestGrid.Rejected;


                    this.ProcessActionRequest(CurrentAction, row);
                }
                if (target.hasClass('Review-action')) {
                    this.ProcessReviewRequest(item);
                }


            }


        }
        protected ProcessActionRequest(CurrentAction: string, row: number) {
            var item = this.itemAt(row);



            if (CurrentAction == ProjectMaterialRequestGrid.Approved) {

                item.RequestStatus = ProjectMaterialRequestGrid.RequestStatusApproved;


                Indotalent.Projects.ProjectMaterialRequestService.Update({

                    Entity: item,
                    EntityId: item.Id

                }, response => {
                    Q.notifySuccess("Material Request Approved")
                    this.refresh();



                });
            }
            if (CurrentAction == ProjectMaterialRequestGrid.Rejected) {

                item.RequestStatus = ProjectMaterialRequestGrid.RequestStatusRejected;

                Indotalent.Projects.ProjectMaterialRequestService.Update({

                    Entity: item,
                    EntityId: item.Id

                }, response => {
                    Q.notifySuccess("Material Request Rejected")
                    this.refresh();



                });

            }

        }

        protected ProcessReviewRequest(item: ProjectMaterialRequestRow) {
            var dialog = new ProjectMaterialRequestDialog();
            dialog.loadEntityAndOpenDialog(item);


            dialog.set_readOnly(true);
        }


    }

}

      