

using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using Indotalent.Administration;
using Indotalent.Material;
using Indotalent.Projects;
using Serenity;
using Serenity.Abstractions;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Indotalent.Web.Modules.Projects.ProjectMaterialRequestDetail.RequestHandlers
{
    public class ProjectMaterialRequestDetailPMRIDListRequest : ServiceRequest
    {
      
        public int ProjectMaterialRequestId { get; set; }
    }

    public class ProjectMaterialRequestDetailPMRIDListResponse : ServiceResponse
    {
        public List<ProjectMaterialRequestDetailRow> ProjectMaterialRequestDetails { get; set; }
    }
    public interface IProjectMaterialRequestDetailPMRIDListHandler : IRequestHandler
    {
        ProjectMaterialRequestDetailPMRIDListResponse GetProjectMaterialRequestId(IDbConnection connection, ProjectMaterialRequestDetailPMRIDListRequest request);
    }
    public class ProjectMaterialRequestDetailPMRIDListHandler : IProjectMaterialRequestDetailPMRIDListHandler
    {
        protected IUserAccessor UserAccessor { get; }
        private IUserRetrieveService UserRetriever { get; }
        public ProjectMaterialRequestDetailPMRIDListHandler(IUserAccessor userAccessor, IUserRetrieveService userRetriever)
        {
            UserAccessor = userAccessor;
            UserRetriever = userRetriever;
        }
        public ProjectMaterialRequestDetailPMRIDListResponse GetProjectMaterialRequestId(IDbConnection connection, ProjectMaterialRequestDetailPMRIDListRequest request)
        {
            var user = UserAccessor.User?.GetUserDefinition(UserRetriever) as UserDefinition;

            var result = new ProjectMaterialRequestDetailPMRIDListResponse();

            var projectMaterialRequestId = request.ProjectMaterialRequestId;
          

              var materialRequestDetails = connection
                .List<ProjectMaterialRequestDetailRow>() 
                .Where(x => x.ProjectMaterialRequestId == projectMaterialRequestId) 
                .ToList();

            
            result.ProjectMaterialRequestDetails = materialRequestDetails;

            //.Where(ProjectMaterialRequestDetailRow.Fields.ProjectMaterialRequestId == projectMaterialRequestId);



            return result;
        }
    }
}

