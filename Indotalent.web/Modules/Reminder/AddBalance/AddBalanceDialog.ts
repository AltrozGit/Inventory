namespace Indotalent.Reminder {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class AddBalanceDialog extends Serenity.EntityDialog<AddBalanceRow, any> {
        protected getFormKey() { return AddBalanceForm.formKey; }
        protected getIdProperty() { return AddBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AddBalanceRow.localTextPrefix; }
        protected getService() { return AddBalanceService.baseUrl; }
        protected getDeletePermission() { return AddBalanceRow.deletePermission; }
        protected getInsertPermission() { return AddBalanceRow.insertPermission; }
        protected getUpdatePermission() { return AddBalanceRow.updatePermission; }

        protected form = new AddBalanceForm(this.idPrefix);

        constructor() {
            super();
            
            this.form.RechargeDate.changeSelect2(e => this.updateValidThrough());
            this.form.Frequency.changeSelect2(e => this.updateValidThrough());
            this.form.PlanId.changeSelect2((args) => {
                var PlanId = this.form.PlanId.value;
                if (Q.isEmptyOrNull(PlanId)) {
                    return;
                }

                PlanSettingService.Retrieve({
                    EntityId: PlanId,
                }, response => {
                    this.form.Cost.value = response.Entity.Cost||0;
                    this.form.Frequency.value = response.Entity.Frequency.toString();
                    this.form.Type.value = response.Entity.Type.toString();
                  
                    this.form.Units.value = response.Entity.Units;
                });
            });
        }
        private updateValidThrough() {
            const rechargeValue = this.form.RechargeDate.value;
            const frequency = this.form.Frequency.value;

            if (!rechargeValue || !frequency)
                return;

            const rechargeDate = Q.parseISODateTime(rechargeValue);
            if (!rechargeDate)
                return;

            let validThrough = new Date(rechargeDate); 
            switch (frequency.toLowerCase()) {
                case "monthly":
                    validThrough.setMonth(validThrough.getMonth() + 1);
                    break;
                case "quarterly":
                    validThrough.setMonth(validThrough.getMonth() + 3);
                    break;
                case "yearly":
                    validThrough.setFullYear(validThrough.getFullYear() + 1);
                    break;
                default:
                    return;
            }

            validThrough.setDate(validThrough.getDate() - 1);

            // Assign back as formatted string
            this.form.ValidThrough.value = Q.formatDate(validThrough, 'yyyy-MM-dd');
        }

        protected updateInterface(): void {
            super.updateInterface();
           
            if (!this.isNew) {
                Serenity.EditorUtils.setReadOnly(this.form.CustomerId, true);
                Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
                Serenity.EditorUtils.setReadOnly(this.form.PlanId, true);
                Serenity.EditorUtils.setReadOnly(this.form.ApplicationTenantId, true);
                Serenity.EditorUtils.setReadOnly(this.form.RechargeDate, true);
                Serenity.EditorUtils.setReadOnly(this.form.ValidThrough, true);


            }
        }
      

        protected afterLoadEntity() {
            super.afterLoadEntity();
          
            if (!this.isNew()) {
               

                this.setFieldsotherReadOnly();
            }
            
            this.setFieldsReadOnly();
            if (this.form.RechargeDate.value && this.form.Frequency.value) {
                this.updateValidThrough();
            }
            const isAdmin = Q.Authorization.hasPermission("Administration:Tenant");

            //if (this.isNew()) {
            //    Q.serviceCall({
            //        url: Q.resolveUrl("~/Services/Reminder/AddBalance/GetTenantId"),
            //        onSuccess: (response: string) => {
            //            this.form.TenantId.value = response;
            //            //if (!isAdmin) {
            //            //    Serenity.EditorUtils.setReadOnly(this.form.TenantId, true);
            //            //}
            //        }
            //    });
            //} else {
            //    this.form.TenantId.value = this.entity.TenantId?.toString();
            //    //if (!isAdmin) {
            //    //    Serenity.EditorUtils.setReadOnly(this.form.TenantId, true);
            //    //}
            //}
        }

        private setFieldsotherReadOnly() {
            Serenity.EditorUtils.setReadOnly(this.form.CustomerId, true);
            Serenity.EditorUtils.setReadOnly(this.form.ProductId, true);
            Serenity.EditorUtils.setReadOnly(this.form.PlanId, true);
            Serenity.EditorUtils.setReadOnly(this.form.ApplicationTenantId, true);
            Serenity.EditorUtils.setReadOnly(this.form.RechargeDate, true);
            Serenity.EditorUtils.setReadOnly(this.form.ValidThrough, true);
        }
        private setFieldsReadOnly() {
          

            Serenity.EditorUtils.setReadOnly(this.form.Cost, true);
         
           
         

            Serenity.EditorUtils.setReadOnly(this.form.Units, true);
            Serenity.EditorUtils.setReadOnly(this.form.Type, true);

            Serenity.EditorUtils.setReadOnly(this.form.Frequency, true);
        

        }
    }
}
