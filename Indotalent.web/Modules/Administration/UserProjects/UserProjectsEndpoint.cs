using Indotalent.Administration;
using Microsoft.AspNetCore.Mvc;
using Serenity.Data;
using Serenity.Services;
using System.Data;
using MyRepository = Indotalent.Administration.Repositories.UserProjectsRepository;
//using MyRow = Indotalent.Administration.UserProjectsRow;
using MyRow = Indotalent.Administration.UserProjectsRow;

namespace Indotalent.Administration
{
    [Route("Services/Administration/UserProjects/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class UserProjectsController : ServiceEndpoint
    {
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, UserProjectsUpdateRequest request)
        {
            return new MyRepository(Context).Update(uow, request);
        }

        public UserProjectsListResponse List(IDbConnection connection, UserProjectsListRequest request)
        {
            return new MyRepository(Context).List(connection, request);
        }
    }
}
