namespace Indotalent.Projects {
    export interface ProjectFundRow {
        Id?: number;
        ProjectId?: number;
        AddedFund?: number;
        FundingDate?: string;
        Description?: string;
        TenantId?: number;
        TenantName?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }

    export namespace ProjectFundRow {
        export const idProperty = 'Id';
        export const localTextPrefix = 'Projects.ProjectFund';
        export const lookupKey = 'Projects.ProjectFund';

        export function getLookup(): Q.Lookup<ProjectFundRow> {
            return Q.getLookup<ProjectFundRow>('Projects.ProjectFund');
        }
        export const deletePermission = 'Projects:ProjectFund';
        export const insertPermission = 'Projects:ProjectFund';
        export const readPermission = 'Projects:ProjectFund';
        export const updatePermission = 'Projects:ProjectFund';

        export declare const enum Fields {
            Id = "Id",
            ProjectId = "ProjectId",
            AddedFund = "AddedFund",
            FundingDate = "FundingDate",
            Description = "Description",
            TenantId = "TenantId",
            TenantName = "TenantName",
            InsertUserId = "InsertUserId",
            InsertDate = "InsertDate",
            UpdateUserId = "UpdateUserId",
            UpdateDate = "UpdateDate"
        }
    }
}
