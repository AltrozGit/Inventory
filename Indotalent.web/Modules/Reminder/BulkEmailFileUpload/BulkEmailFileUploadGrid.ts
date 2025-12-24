

namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()

    export class BulkEmailFileUploadGrid extends Serenity.EntityGrid<BulkEmailFileUploadRow, any> {
        private isShowingNewColumns: boolean = false;
        private originalColumns: Slick.Column[];

        constructor(container: JQuery) {
            super(container);
         
            this.bindClickEvents();
            this.checkColumnStateOnLoad();
                
            }
        
    
          
        

        protected getColumnsKey() { return BulkEmailFileUploadColumns.columnsKey; }
        protected getDialogType() { return BulkEmailFileUploadDialog; }
        protected getIdProperty() { return BulkEmailFileUploadRow.idProperty; }
        protected getInsertPermission() { return BulkEmailFileUploadRow.insertPermission; }
        protected getLocalTextPrefix() { return BulkEmailFileUploadRow.localTextPrefix; }
        protected getService() { return BulkEmailFileUploadService.baseUrl; }

        protected getColumns() {
            let columns = super.getColumns();
       
            if (!Q.Authorization.hasPermission("Administration:Tenant")) {
                columns = columns.filter(x => x.field != BulkEmailFileUploadRow.Fields.TenantName && x.field != BulkEmailFileUploadRow.Fields.Id);
            }
            
            columns.unshift({
                field: 'Title',
                name: 'Title',
                format: ctx => `<a href="javascript:;" class="file-link" data-file-id="${ctx.item.Id}">${Q.htmlEncode(ctx.item.Title)}</a>`,
                width: 300,
                sortable: true
            });
            columns.push({
                field: 'Action',
                name: 'Action',
                format: ctx => {
                    let disabled = ctx.item.IsStopped ? 'disabled' : '';
                    return `<button class="stop-button" data-id="${ctx.item.Id}" ${disabled}>Stop</button>`;
                },
                width: 200,
                sortable: false
            });
            if (Q.Authorization.hasPermission("Administration:User")) {
                columns.push({
                    field: 'IsActive',
                    name: 'Is Active',
                    format: ctx => {
                        const isActive = ctx.item.IsActive;
                        const buttonClass = isActive ? 'btn btn-success' : 'btn btn-danger';
                        const buttonText = isActive ? 'Disable' : 'Enable';
                        return `<button class="${buttonClass} toggle-active" data - id="${ctx.item.Id}" > ${ buttonText } </button>`;
                    },
                    width: 100,
                    sortable: false
                });
            }
            this.originalColumns = columns;
            return columns;
        }
    


        protected getButtons() {
            var buttons = super.getButtons();

            buttons.push({
                title: Q.text("Download File Template"),
                cssClass: 'fileExport-button',
                onClick: () => {
                    let ServiceEndpoint = this.getService() + "/DownloadFileTemplate";
                    Q.postToService({ service: ServiceEndpoint, request: {}, target: '_blank' });
                    Q.notifySuccess(Q.text("File Downloaded Successfully"));
                }
            });
           
            return buttons;
        }

        private resetToOriginalView() {
            if (this.isShowingNewColumns) {
                this.slickGrid.setColumns(this.originalColumns);
                this.isShowingNewColumns = false;
                this.refresh();
                this.removeBackButton();
            }
        }

        private bindClickEvents() {
            this.slickGrid.onClick.subscribe((e, args) => {
                let $target = $(e.target);

                if ($target.hasClass('file-link')) {
                    let item = this.view.getItem(args.row);
                    let bulkEmailSenderId = item.Id;

                    if (bulkEmailSenderId) {
                        this.showBulkEmailSenderDetails(bulkEmailSenderId);
                    }

                }

                else if ($target.hasClass('stop-button')) {
                    let item = this.view.getItem(args.row);
                    let bulkEmailSenderId = item.Id;

                    Q.confirm("Are you sure you want to stop this upload?", () => {
                        $target.prop("disabled", true).addClass("disabled");
                        BulkEmailFileUploadService.StopEmailNotifications({
                            BulkEmailSenderId: bulkEmailSenderId
                        }, response => {
                            Q.notifySuccess("Email sending stopped successfully!");
                            item.IsStopped = true;
                            item.IsSent = 2; // 2 represents Cancelled status
                            item.IsSentDisplay = 'Cancelled'; 
                            this.view.updateItem(item.Id, item); // Update view to change button state
                          

                            // Refresh the view to ensure button remains disabled
                            this.slickGrid.invalidateRow(args.row);
                            this.slickGrid.render();
                        });
                    });
                }
                if ($target.hasClass('toggle-active')) {
                    let item = this.view.getItem(args.row);
                    const bulkEmailFileId = item.Id;
                    const newIsActiveStatus = !item.IsActive;

                    Q.confirm(`Are you sure you want to ${newIsActiveStatus ? 'enable' : 'disable'} this file?`, () => {
                        BulkEmailFileUploadService.ToggleActiveStatus({
                            BulkEmailFileId: bulkEmailFileId,
                            IsActive: newIsActiveStatus
                        }, response => {
                            Q.notifySuccess(`File ${newIsActiveStatus ? 'enabled' : 'disabled'} successfully!`);
                            item.IsActive = newIsActiveStatus;
                            this.view.updateItem(item.Id, item);
                        });
                    });
                }
               
            });
        }
    
     
       



        private showBulkEmailSenderDetails(bulkEmailSenderId: number) {
            let newColumns: Slick.Column[] = [
                { field: 'ToEmail', name: 'To Email', width: 200 },
                { field: 'Subject', name: 'Subject', width: 300 },
                {
                    field: 'SentOn',
                    name: 'Sent On',
                    width: 300,
                    formatter: (row, cell, value) => {
                        if (value) {
                            const date = new Date(value);
                            return date.toISOString().slice(0, 19).replace('T', ' ');
                        }
                        return '';
                    }
                },
                { field: 'RetryCount', name: 'Retry Count', width: 100 },
                { field: 'IsSentDisplay', name: 'Sent Status', width: 100 }
            ];

            this.slickGrid.setColumns(newColumns);
            this.isShowingNewColumns = true;
            this.refreshGridData(bulkEmailSenderId);
            setTimeout(() => {
                this.refreshGridData(bulkEmailSenderId);
            }, 100); // Small delay for smoother UI transition
            this.addBackButton();
        }

        private addBackButton() {
            let toolbar = this.toolbar.element;

            // Only add the button if it doesn't already exist
            if (toolbar.find(".back-button").length === 0) {
                toolbar.append(
                    `<button class="back-button btn btn-default" title="Back">
                        <i class="fa fa-arrow-left"></i>
                    </button>`
                );

                toolbar.find(".back-button").click(() => {
                    this.resetToOriginalView();
                });
            }
        }

        private removeBackButton() {
            let toolbar = this.toolbar.element;
            toolbar.find(".back-button").remove();
        }

        private refreshGridData(bulkEmailSenderId: number) {
            BulkEmailSenderStatusService.List({
                EqualityFilter: { BulkEmailSenderId: bulkEmailSenderId },
            }, response => {
                this.view.setItems(response.Entities, true);
              
            });
        }

        protected onViewSubmit(): boolean {
            if (!super.onViewSubmit()) {
                return false;
            }

            if (!this.isShowingNewColumns) {
                this.slickGrid.setColumns(this.originalColumns);
            }

            let request = this.view.params as Serenity.ListRequest;
            request.Take = 20;
            request.Sort = ['InsertDate desc'];
            if (!Q.Authorization.hasPermission("Administration:Admin")) {
                request.Criteria = Serenity.Criteria.and(request.Criteria, [['IsActive'], '=', true]);
            }
            return true;
        }

        private checkColumnStateOnLoad() {
            if (this.isShowingNewColumns) {
                this.slickGrid.setColumns(this.originalColumns);
                this.isShowingNewColumns = false;
            }
        }
    }
}


