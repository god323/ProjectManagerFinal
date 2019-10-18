using ProjectManagerBLL;
using ProjectManagerWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagerWebApi.Controllers
{
    public class ProjectApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            var objService = new ProjectService();
            var List = objService.Display();
            var BindingList = new List<ProjectBindingModel>();
            foreach (var item in List)
            {
                BindingList.Add(new ProjectBindingModel()
                {
                    ProjectId = item.ProjectId,
                    ProjectTitle = item.ProjectTitle,
                    ProjectStartDate = item.ProjectStartDate,
                    ProjectEndDate = item.ProjectEndDate,
                    EmployeeId = item.EmployeeId
                });
            }
            return Ok(BindingList);
        } 
    }
}
