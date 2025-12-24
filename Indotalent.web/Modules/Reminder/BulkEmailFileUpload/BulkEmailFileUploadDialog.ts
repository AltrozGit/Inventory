
namespace Indotalent.Reminder {
    export declare function Submit(request: { FilePath: string, BulkEmailSenderId: number }, onSuccess?: (response: any) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class BulkEmailFileUploadDialog extends Serenity.EntityDialog<BulkEmailFileUploadRow, any> {
        loadedState: string;
        protected getFormKey() { return BulkEmailFileUploadForm.formKey; }
        protected getIdProperty() { return BulkEmailFileUploadRow.idProperty; }
        protected getLocalTextPrefix() { return BulkEmailFileUploadRow.localTextPrefix; }
        protected getNameProperty() { return BulkEmailFileUploadRow.nameProperty; }
        protected getService() { return BulkEmailFileUploadService.baseUrl; }
        protected getDeletePermission() { return BulkEmailFileUploadRow.deletePermission; }
        protected getInsertPermission() { return BulkEmailFileUploadRow.insertPermission; }
        protected getUpdatePermission() { return BulkEmailFileUploadRow.updatePermission; }

        protected form = new BulkEmailFileUploadForm(this.idPrefix);

        constructor() {
            super();



            Indotalent.DialogUtils.pendingChangesConfirmation(this.element, () => this.getSaveState() != this.loadedState);

            // Function to manually pad numbers to 2 digits
            function padToTwoDigits(number: number): string {
                return number < 10 ? '0' + number : number.toString();

            }


            // Extend the file upload editor
            this.form.FilePath.element.change(e => {
                let input = e.target as HTMLInputElement;
                if (input.files && input.files.length > 0) {
                    let fileName = input.files[0].name;
                    let fileTitle = fileName.substring(0, fileName.lastIndexOf('.')) || fileName;

                    // Get the current date and time
                    let now = new Date();
                    let year = now.getFullYear().toString();
                    let month = padToTwoDigits(now.getMonth() + 1); // Months are 0-based, so we add 1
                    let day = padToTwoDigits(now.getDate());
                    let hours = padToTwoDigits(now.getHours());
                    let minutes = padToTwoDigits(now.getMinutes());

                    // Create formatted string "yyyyMMdd_HHmm"
                    let formattedTimestamp = `${year}${month}${day}_${hours}${minutes}`;

                    // Append the formatted timestamp to the file title
                    fileTitle = fileTitle.concat("_" + formattedTimestamp);

                    // Set the title field to the new file title
                    this.form.Title.value = fileTitle;

                }
            });
        }
        //protected onSaveSuccess(response: Serenity.ServiceResponse): void {
        //    super.onSaveSuccess(response);

        //    // Handle success and error messages
        //    const customResponse = response as any;
        //    if (customResponse.successMessages) {
        //        customResponse.successMessages.forEach((message: string) => {
        //            Q.notifySuccess(message);
        //        });
        //    }

        //    if (customResponse.errorMessages) {
        //        customResponse.errorMessages.forEach((message: string) => {
        //            Q.notifyError(message);
        //        });
        //    }
        //}
        protected save(callback?: (response: Serenity.SaveResponse) => void): boolean | void {
            Q.serviceCall({
                url: '/Services/Reminder/BulkEmailFileUpload/GetTenantId',
                onSuccess: (tenantId: string) => {
                    if (!tenantId) {
                        Q.notifyError("TenantId is missing.");
                        return; // Stop execution if tenantId is missing
                    }

                    // Proceed with saving the record
                    super.save(response => {
                        const customResponse = response as any;

                        // Show custom error message if it exists and prevent further execution
                        if (customResponse.CustomErrorMessage) {
                            Q.notifyError(customResponse.CustomErrorMessage, "Validation Error");
                            return; // Stop execution if there's an error
                        }

                        // Show custom warning message if it exists
                        if (customResponse.CustomWarningMessage) {
                            Q.notifyWarning(customResponse.CustomWarningMessage, "Warning");
                          
                        }

                        // Save the record and notify success
                        if (callback) {
                            callback(response);
                        }

                        Q.notifySuccess("Record Saved successfully.", "Success");
                        super.onSaveSuccess(response);
                    });
                },
                onError: () => {
                    Q.notifyError("Failed to retrieve TenantId.", "Error");
                }
            });
        }

        //protected save(): void {
        //    Q.serviceCall({
        //        url: '/Services/Reminder/BulkEmailFileUpload/GetTenantId',
        //        onSuccess: (tenantId: string) => {
        //            if (!tenantId) {
        //                Q.notifyError("TenantId is missing.");
        //                return;
        //            }

        //            Q.serviceCall({
        //                url: '/Services/Reminder/BulkEmailFileUpload/CheckSubscription',
        //                request: { TenantId: tenantId },
        //                onSuccess: (response: CheckSubscriptionResponse) => {
        //                    if (!response || typeof response.IsActive === 'undefined' || typeof response.EndDate === 'undefined' || typeof response.CurrentBalanceUnits === 'undefined') {
        //                        Q.notifyError("Invalid response received from subscription check.");
        //                        return;
        //                    }

        //                    const currentDate = new Date();
        //                    const endDate = new Date(response.EndDate);

        //                    if (!response.IsActive) {
        //                        Q.notifyError("Subscription is inactive or expired. Please renew your subscription.");
        //                        return;
        //                    }

        //                    if (currentDate > endDate) {
        //                        Q.notifyError("Subscription has expired. Please renew to continue.");
        //                        return;
        //                    }

        //                    // All checks passed, now proceed to save the record
        //                    super.save();

        //                    //    return;
        //                    //}

        //                    //if (this.isDialogOpen()) {
        //                    //    this.triggerRecordSavedEvent();
        //                    //    super.save();
        //                    //    this.dialogClose();
        //                    //    Q.notifySuccess("Record Saved Successfully");
        //                    //}

        //                    // Close the dialog before saving
        //                    super.save();

        //                    this.dialogClose();

        //                    // Now save the record and show the success message
        //                    Q.notifySuccess("Record Saved Successfully");


        //                },
        //                onError: (error) => {
        //                    console.error("CheckSubscription error: ", error);
        //                    Q.notifyError("Error while checking subscription: " + (error?.Error || "Unknown error"));
        //                }
        //            });
        //        },
        //        onError: (error) => {
        //            console.error("GetTenantId error: ", error);
        //            Q.notifyError("Error while fetching TenantId.");
        //        }
        //    });
        //}

        //private isDialogOpen(): boolean {
        //    return this.element && this.element.is(':visible');
        //}

        //// Helper method to trigger recordSaved event
        //private triggerRecordSavedEvent(): void {
        //    if (!this.element || typeof this.element.triggerHandler !== 'function') {
        //        console.warn("Cannot trigger 'recordSaved' event because the element is null or not ready.");
        //        return;
        //    }
        //    this.element.triggerHandler('recordSaved');
        //}
        protected afterLoadEntity() {
                    super.afterLoadEntity();
                    //const tenantId = 1;
                    //console.log("TenantId:", tenantId); // Debugging line to check if TenantId is correctly retrieved

                    //// Call the check subscription function
                    //if (tenantId) {
                    //    this.checkSubscription(tenantId);
                    //} else {
                    //    Q.notifyError("TenantId is not available.");
                    //}

                    if (this.isNew()) {
                        const smtpLookup = Q.getLookup("Reminder.SmtpConfigurationLookup");
                        if (smtpLookup && smtpLookup.items && smtpLookup.items.length > 0) {
                            (smtpLookup.items as SmtpConfigurationItem[]).forEach(item => {
                                if (item.IsDefault) {
                                    this.form.FromAddress.value = item.FromAddress;
                                }
                            });
                        }
                    }


                    this.toolbar.findButton('apply-changes-button').hide();
                }
                //// The checkSubscription function as defined earlier
                //checkSubscription(tenantId: number): void {
                //    console.log("Sending TenantId to the server:", tenantId); // Debugging line
                //    $.ajax({
                //        url: '/Services/Reminder/BulkEmailFileUpload/CheckSubscription/' + tenantId,
                //        type: 'POST',
                //        contentType: 'application/json',
                //        dataType: 'json',
                //        data: JSON.stringify({ TenantId: tenantId }),
                //        success: (response: any) => {
                //            // Check if subscription is active
                //            if (!response.IsActive) {
                //                Q.notifyError("No active subscription");
                //            }
                //        },
                //        error: (xhr: JQueryXHR, status: string, error: string) => {
                //            // Display error message
                //            $('#subscriptionStatus').html('<p style="color: red;">Error checking subscription: ' + error + '</p>');
                //        }
                //    });
                //}


                //protected onSaveSuccess(response: Serenity.SaveResponse): void {
                //    super.onSaveSuccess(response); // Ensure any default behavior is executed
                //    const customResponse = response as any;
                //        if (customResponse.successMessages) {
                //            customResponse.successMessages.forEach((message: string) => {
                //                Q.notifySuccess(message);
                //            });
                //        }

                //        if (customResponse.errorMessages) {
                //            customResponse.errorMessages.forEach((message: string) => {
                //                Q.notifyError(message);
                //            });
                //        }

                //}
            
        getSaveState() {
            try {
                return $.toJSON(this.getSaveEntity());
            }
            catch (e) {
                return null;
            }
        }

        loadResponse(data) {
            super.loadResponse(data);
            this.loadedState = this.getSaveState();
        }

        protected getToolbarButtons() {
            let buttons = super.getToolbarButtons();

            //buttons.push({
            //    title: 'Submit',
            //    cssClass: 'submit-button',
            //    icon: 'fa fa-paper-plane',
            //    onClick: () => {
            //        this.submit();
            //    }
            //});

            return buttons;
        }
        protected onDialogOpen() {
            super.onDialogOpen();
        }

 

        protected updateInterface() {
            super.updateInterface();
            // Hide or remove the "Apply Changes" button
            this.toolbar.findButton('apply-changes-button').hide();
        }
    }
    interface SmtpConfigurationItem {
        IsDefault: boolean;
        FromAddress: string;
    }
    }

      
