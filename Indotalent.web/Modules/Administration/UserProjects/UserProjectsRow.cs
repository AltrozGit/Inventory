using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace Indotalent.Administration
{
    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[UserProjects]")]
    [DisplayName("User Projects"), InstanceName("User Projects")]
	[ReadPermission(PermissionKeys.Security)]
	[ModifyPermission(PermissionKeys.Security)]
	public sealed class UserProjectsRow : Row<UserProjectsRow.RowFields>, IIdRow
    {
        [DisplayName("User Projects Id"), Identity, IdProperty]
        public Int64? UserProjectsId
        {
            get => fields.UserProjectsId[this];
            set => fields.UserProjectsId[this] = value;
        }

        [DisplayName("User"), NotNull, ForeignKey("[dbo].[Users]", "UserId"), LeftJoin("jUser"), TextualField("Username")]
        public Int32? UserId
        {
            get => fields.UserId[this];
            set => fields.UserId[this] = value;
        }

        [DisplayName("Project"), NotNull, ForeignKey("[dbo].[Project]", "Id"), LeftJoin("jProject"), TextualField("ProjectName")]
        public Int32? ProjectId
        {
            get => fields.ProjectId[this];
            set => fields.ProjectId[this] = value;
        }

        [DisplayName("User Username"), Expression("jUser.[Username]")]
        public String Username
        {
            get => fields.Username[this];
            set => fields.Username[this] = value;
        }

        [DisplayName("User Display Name"), Expression("jUser.[DisplayName]")]
        public String User
        {
            get => fields.User[this];
            set => fields.User[this] = value;
        }

        //[DisplayName("User Email"), Expression("jUser.[Email]")]
        //public String UserEmail
        //{
        //    get => fields.UserEmail[this];
        //    set => fields.UserEmail[this] = value;
        //}

        //[DisplayName("User Source"), Expression("jUser.[Source]")]
        //public String UserSource
        //{
        //    get => fields.UserSource[this];
        //    set => fields.UserSource[this] = value;
        //}

        //[DisplayName("User Last Directory Update"), Expression("jUser.[LastDirectoryUpdate]")]
        //public DateTime? UserLastDirectoryUpdate
        //{
        //    get => fields.UserLastDirectoryUpdate[this];
        //    set => fields.UserLastDirectoryUpdate[this] = value;
        //}

        //[DisplayName("User User Image"), Expression("jUser.[UserImage]")]
        //public String UserUserImage
        //{
        //    get => fields.UserUserImage[this];
        //    set => fields.UserUserImage[this] = value;
        //}

        //[DisplayName("User Insert Date"), Expression("jUser.[InsertDate]")]
        //public DateTime? UserInsertDate
        //{
        //    get => fields.UserInsertDate[this];
        //    set => fields.UserInsertDate[this] = value;
        //}

        //[DisplayName("User Insert User Id"), Expression("jUser.[InsertUserId]")]
        //public Int32? UserInsertUserId
        //{
        //    get => fields.UserInsertUserId[this];
        //    set => fields.UserInsertUserId[this] = value;
        //}

        //[DisplayName("User Update Date"), Expression("jUser.[UpdateDate]")]
        //public DateTime? UserUpdateDate
        //{
        //    get => fields.UserUpdateDate[this];
        //    set => fields.UserUpdateDate[this] = value;
        //}

        //[DisplayName("User Update User Id"), Expression("jUser.[UpdateUserId]")]
        //public Int32? UserUpdateUserId
        //{
        //    get => fields.UserUpdateUserId[this];
        //    set => fields.UserUpdateUserId[this] = value;
        //}

        //[DisplayName("User Is Active"), Expression("jUser.[IsActive]")]
        //public Int16? UserIsActive
        //{
        //    get => fields.UserIsActive[this];
        //    set => fields.UserIsActive[this] = value;
        //}

        //[DisplayName("User Is Tenant Admin"), Expression("jUser.[IsTenantAdmin]")]
        //public Boolean? UserIsTenantAdmin
        //{
        //    get => fields.UserIsTenantAdmin[this];
        //    set => fields.UserIsTenantAdmin[this] = value;
        //}

        //[DisplayName("User Tenant Id"), Expression("jUser.[TenantId]")]
        //public Int32? UserTenantId
        //{
        //    get => fields.UserTenantId[this];
        //    set => fields.UserTenantId[this] = value;
        //}

        //[DisplayName("Project Name"), Expression("jProject.[Name]")]
        //public String ProjectName
        //{
        //    get => fields.ProjectName[this];
        //    set => fields.ProjectName[this] = value;
        //}

        //[DisplayName("Project Description"), Expression("jProject.[Description]")]
        //public String ProjectDescription
        //{
        //    get => fields.ProjectDescription[this];
        //    set => fields.ProjectDescription[this] = value;
        //}

        //[DisplayName("Project Street"), Expression("jProject.[Street]")]
        //public String ProjectStreet
        //{
        //    get => fields.ProjectStreet[this];
        //    set => fields.ProjectStreet[this] = value;
        //}

        //[DisplayName("Project City"), Expression("jProject.[City]")]
        //public String ProjectCity
        //{
        //    get => fields.ProjectCity[this];
        //    set => fields.ProjectCity[this] = value;
        //}

        //[DisplayName("Project State"), Expression("jProject.[State]")]
        //public String ProjectState
        //{
        //    get => fields.ProjectState[this];
        //    set => fields.ProjectState[this] = value;
        //}

        //[DisplayName("Project Zip Code"), Expression("jProject.[ZipCode]")]
        //public String ProjectZipCode
        //{
        //    get => fields.ProjectZipCode[this];
        //    set => fields.ProjectZipCode[this] = value;
        //}

        //[DisplayName("Project Phone"), Expression("jProject.[Phone]")]
        //public String ProjectPhone
        //{
        //    get => fields.ProjectPhone[this];
        //    set => fields.ProjectPhone[this] = value;
        //}

        //[DisplayName("Project Email"), Expression("jProject.[Email]")]
        //public String ProjectEmail
        //{
        //    get => fields.ProjectEmail[this];
        //    set => fields.ProjectEmail[this] = value;
        //}

        //[DisplayName("Project Insert Date"), Expression("jProject.[InsertDate]")]
        //public DateTime? ProjectInsertDate
        //{
        //    get => fields.ProjectInsertDate[this];
        //    set => fields.ProjectInsertDate[this] = value;
        //}

        //[DisplayName("Project Insert User Id"), Expression("jProject.[InsertUserId]")]
        //public Int32? ProjectInsertUserId
        //{
        //    get => fields.ProjectInsertUserId[this];
        //    set => fields.ProjectInsertUserId[this] = value;
        //}

        //[DisplayName("Project Update Date"), Expression("jProject.[UpdateDate]")]
        //public DateTime? ProjectUpdateDate
        //{
        //    get => fields.ProjectUpdateDate[this];
        //    set => fields.ProjectUpdateDate[this] = value;
        //}

        //[DisplayName("Project Update User Id"), Expression("jProject.[UpdateUserId]")]
        //public Int32? ProjectUpdateUserId
        //{
        //    get => fields.ProjectUpdateUserId[this];
        //    set => fields.ProjectUpdateUserId[this] = value;
        //}

        //[DisplayName("Project Tenant Id"), Expression("jProject.[TenantId]")]
        //public Int32? ProjectTenantId
        //{
        //    get => fields.ProjectTenantId[this];
        //    set => fields.ProjectTenantId[this] = value;
        //}

        public UserProjectsRow()
            : base()
        {
        }

        public UserProjectsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field UserProjectsId;
            public Int32Field UserId;
            public Int32Field ProjectId;

            public StringField Username;
            public StringField User;
            //public StringField UserEmail;
            //public StringField UserSource;
            //public DateTimeField UserLastDirectoryUpdate;
            //public StringField UserUserImage;
            //public DateTimeField UserInsertDate;
            //public Int32Field UserInsertUserId;
            //public DateTimeField UserUpdateDate;
            //public Int32Field UserUpdateUserId;
            //public Int16Field UserIsActive;
            //public BooleanField UserIsTenantAdmin;
            //public Int32Field UserTenantId;

            //public StringField ProjectName;
            //public StringField ProjectDescription;
            //public StringField ProjectStreet;
            //public StringField ProjectCity;
            //public StringField ProjectState;
            //public StringField ProjectZipCode;
            //public StringField ProjectPhone;
            //public StringField ProjectEmail;
            //public DateTimeField ProjectInsertDate;
            //public Int32Field ProjectInsertUserId;
            //public DateTimeField ProjectUpdateDate;
            //public Int32Field ProjectUpdateUserId;
            //public Int32Field ProjectTenantId;
        }
    }
}
