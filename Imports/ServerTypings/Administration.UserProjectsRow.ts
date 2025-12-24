namespace Indotalent.Administration {
    export interface UserProjectsRow {
        UserProjectsId?: number;
        UserId?: number;
        ProjectId?: number;
        Username?: string;
        User?: string;
    }

    export namespace UserProjectsRow {
        export const idProperty = 'UserProjectsId';
        export const localTextPrefix = 'Administration.UserProjects';
        export const deletePermission = 'Administration:Security';
        export const insertPermission = 'Administration:Security';
        export const readPermission = 'Administration:Security';
        export const updatePermission = 'Administration:Security';

        export declare const enum Fields {
            UserProjectsId = "UserProjectsId",
            UserId = "UserId",
            ProjectId = "ProjectId",
            Username = "Username",
            User = "User"
        }
    }
}
