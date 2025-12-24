using FluentMigrator;


namespace Indotalent.Migrations.DefaultDB
{
    [Migration(20250619105558)]
    public class DefaultDB_20250626_104058_alterDueDateReminder : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
CREATE PROCEDURE [dbo].[InsertTemplate]

    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the template already exists to prevent duplicate insert
    IF NOT EXISTS (
        SELECT 1
        FROM [dbo].[Template]
        WHERE TemplateName = 'Subscription Reminder'
          AND TenantId = @TenantId
    )
    BEGIN
        INSERT INTO [dbo].[Template]
            ([TemplateName], [Body], [Parameter], [InsertDate], [InsertUserId], [IsActive], [TenantId])
        VALUES
            (
                'Subscription Reminder',
                '<p>Hello <b>{0}</b>,</p>' +
                '<p>Your subscription for <b>{1}</b> is coming up for renewal on <b>{2}</b>.</p>' +
                '<p>To continue enjoying uninterrupted service, please renew your plan before the renewal date.</p>' +
                '<p>Thank you.</p>',
                '{0}, {1}, {2}',
                GETDATE(),
                null,
                1,  -- IsActive = true
                @TenantId
            );
    END
    ELSE
    BEGIN
        PRINT 'Template already exists for the given tenant.';
    END
END;

        ");
        }
    }
}