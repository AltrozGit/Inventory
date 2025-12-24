namespace Indotalent.Administration {

    @Serenity.Decorators.registerClass()
    export class UserProjectsDialog extends Serenity.TemplatedDialog<UserProjectsDialogOptions> {

        private permissions: ProjectsCheckEditor;

        constructor(opt: UserProjectsDialogOptions) {
            super(opt);

            this.permissions = new ProjectsCheckEditor(this.byId('Projects'));

            UserProjectsService.List({
                UserID: this.options.userID
            }, response => {
                this.permissions.value = response.Entities.map(x => x.toString());
            });
        }

        protected getDialogOptions() {
            var opt = super.getDialogOptions();

            opt.buttons = [{
                text: Q.text('Dialogs.OkButton'),
                click: () => {
                    Q.serviceRequest('Administration/UserProjects/Update', {
                        UserID: this.options.userID,
                        Projects: this.permissions.value.map(x => parseInt(x, 10))
                    }, response => {
                        this.dialogClose();
                        Q.notifySuccess(Q.text('Site.UserProjectsDialog.SaveSuccess'));
                    });
                }
            }, {
                text: Q.text('Dialogs.CancelButton'),
                click: () => this.dialogClose()
            }];

            opt.title = Q.format(Q.text('Site.UserProjectsDialog.DialogTitle'), this.options.username);
            return opt;
        }

        protected getTemplate() {
            return "<div id='~_Projects'></div>";
        }
    }

    export interface UserProjectsDialogOptions {
        userID: number;
        username: string;
    }
}