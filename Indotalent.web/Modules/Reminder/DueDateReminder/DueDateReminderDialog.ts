namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    export class DueDateReminderDialog extends Serenity.EntityDialog<DueDateReminderRow, any> {
        protected getFormKey() { return DueDateReminderForm.formKey; }
        protected getIdProperty() { return DueDateReminderRow.idProperty; }
        protected getLocalTextPrefix() { return DueDateReminderRow.localTextPrefix; }
        protected getNameProperty() { return DueDateReminderRow.nameProperty; }
        protected getService() { return DueDateReminderService.baseUrl; }
        protected getDeletePermission() { return DueDateReminderRow.deletePermission; }
        protected getInsertPermission() { return DueDateReminderRow.insertPermission; }
        protected getUpdatePermission() { return DueDateReminderRow.updatePermission; }

        protected form = new DueDateReminderForm(this.idPrefix);
        private TenantId: string;

        constructor() {
            super();
           

            this.form.CustomerId.changeSelect2(args => {
                const customerId = this.form.CustomerId.value;
                if (Q.isEmptyOrNull(customerId)) {
                    return;
                }
                this.GetCustomerDetails(customerId);
            });

         
            this.form.SendRemainderOnWhatsapp.change(e => {
                this.updateDisplayedDetails();
            });

          
            this.form.SendRemainderOnEmail.change(e => {
                this.updateDisplayedDetails();
            });

            this.form.ConsentDueDate.changeSelect2(args => {
                const consentDueDateValue = this.form.ConsentDueDate.value;

                if (consentDueDateValue) {
                    const consentDueDate = new Date(consentDueDateValue);

                    // Calculate Remainder1 and Remainder2 dates
                    const remainder1Date = new Date(consentDueDate.getTime());
                    remainder1Date.setDate(consentDueDate.getDate() - 3);

                    const remainder2Date = new Date(consentDueDate.getTime());
                    remainder2Date.setDate(consentDueDate.getDate() - 1);

                    // Validate Remainder1 and Remainder2 dates
                    if (remainder1Date >= consentDueDate) {
                        Q.notifyError("Remainder1 must be earlier than Consent Due Date.");
                    } else {
                        this.form.Remainder1.value = remainder1Date.toISOString().split('T')[0];
                    }

                    if (remainder2Date >= consentDueDate) {
                        Q.notifyError("Remainder2 must be earlier than Consent Due Date.");
                    } else {
                        this.form.Remainder2.value = remainder2Date.toISOString().split('T')[0];
                    }
                }
            });
        }
        protected save(callback?: (response: Serenity.SaveResponse) => void): boolean | void {
            return super.save(response => {
                const customResponse = response as any;

                // Check if there's a custom error message and show it using Q.notifyError
                if (customResponse.CustomErrorMessage) {
                    Q.notifyError(customResponse.CustomErrorMessage, "Validation Error");
                } else {
                    // If there's no custom error message, proceed with success or call the callback
                    if (callback) {
                        callback(response);
                    }
                }
                if (!customResponse.CustomErrorMessage) {
                    Q.notifySuccess("Save operation completed successfully.", "Success");

                    super.onSaveSuccess(response);


                }
            });
        }

        



        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (this.isNew()) {
                //this.form.SendRemainderOnEmail.value = true;
                this.form.SendRemainderOnWhatsapp.value = true;

            }

        }

        GetCustomerDetails(customerId: any)
        {
            Sales.CustomerService.Retrieve({
                EntityId: customerId
            }, response => {
                const sendOnWhatsapp = this.form.SendRemainderOnWhatsapp.value;
                const sendOnEmail = this.form.SendRemainderOnEmail.value;
                console.log("tenantId:", response.Entity.TenantId);
                // Clear all fields first
                this.clearAllFields();

                // Populate fields based on the selected checkbox
                if (sendOnWhatsapp) {
                    this.form.CustomerPhone.value = response.Entity.Phone;
                    this.TenantId = String(response.Entity.TenantId);

                }
                if (sendOnEmail) {
                    this.form.ToEmail.value = response.Entity.Email;
                    this.TenantId = String(response.Entity.TenantId);


                }

                // Fetch tenant details if TenantId exists
                if (this.TenantId) {
                    this.GetTenantDetails(this.TenantId);
                } else {
                    console.warn("TenantId is not set.");
                }

                this.updateDisplayedDetails();
            });
        }

        GetTenantDetails(TenantId: any) {
            if (!TenantId) {
                console.error("TenantId is required.");
                return;
            }

            Q.serviceRequest('Reminder/DueDateReminder/GetTenantDetails', {
                TenantId: Number(TenantId)
            }, response => {
                console.log("Tenant Details Response:", response);

                const sendOnWhatsapp = this.form.SendRemainderOnWhatsapp.value;
                const sendOnEmail = this.form.SendRemainderOnEmail.value;

                if (sendOnWhatsapp) {
                    this.form.TenantPhone.value = response.Phone;
                }
                if (sendOnEmail) {
                    this.form.TenantEmail.value = response.Email;
                }

                this.updateDisplayedDetails();
            });
        }
        protected getSaveEntity() {
            const entity = super.getSaveEntity();

          
            if (!this.isNew()) {
                entity.Id = this.entity.Id;
            }

            return entity;
        }

        clearAllFields() {
        
            this.form.CustomerPhone.value = null;
            this.form.TenantPhone.value = null;
            this.form.ToEmail.value = null;
            this.form.TenantEmail.value = null;
        }
        updateDisplayedDetails() {
            const showWhatsappDetails = this.form.SendRemainderOnWhatsapp.value;
            const showEmailDetails = this.form.SendRemainderOnEmail.value;

            // Toggle visibility for WhatsApp-related fields
            if (showWhatsappDetails) {
                $(this.form.CustomerPhone.element).closest('.field').show();
                $(this.form.TenantPhone.element).closest('.field').show();
            } else {
                $(this.form.CustomerPhone.element).closest('.field').hide();
                $(this.form.TenantPhone.element).closest('.field').hide();
            }

            // Toggle visibility for email-related fields
            if (showEmailDetails) {
                $(this.form.ToEmail.element).closest('.field').show();
                $(this.form.TenantEmail.element).closest('.field').show();
            } else {
                $(this.form.ToEmail.element).closest('.field').hide();
                $(this.form.TenantEmail.element).closest('.field').hide();
            }
        }

    }
}
