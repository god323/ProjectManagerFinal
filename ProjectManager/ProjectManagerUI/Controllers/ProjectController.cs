﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Exceptions;
using ProjectManagerBLL;
using ProjectManagerDAL;
using ProjectManagerUI.ViewModels;
using Newtonsoft.Json;
namespace ProjectManagerUI.Controllers
{
    [HandleError]
    public class ProjectsController : Controller
    {
        // GET: Projects
        ProjectService objProjectService = null;
        EmployeeService objEmployeeService = null;
        public ProjectsController()
        {
            objProjectService = new ProjectService();
            objEmployeeService = new EmployeeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ViewProjects()
        //{
        //    try
        //    {
        //        var list = objProjectService.Display();
        //        var ViewList = new List<ProjectViewModel>();
        //        foreach (var item in list)
        //        {
        //            ViewList.Add(new ProjectViewModel()
        //            {
        //                ProjectId = item.ProjectId,
        //                ProjectTitle = item.ProjectTitle,
        //                ProjectStartDate = item.ProjectStartDate,
        //                ProjectEndDate = item.ProjectEndDate,
        //                EmployeeId = item.EmployeeId
        //            });
        //        }
        //        return View("ViewProjects", ViewList);
        //    }
        //    catch (ProjectManagerException e)
        //    {
        //        return Content("Error" + e.Message);
        //    }
        //}


        public async Task<ActionResult> ViewProjects()
        {
            try
            {
                var objApiManager = new ApiManager("http://localhost:65042/");
                var Result = await objApiManager.DisplayTaskAsync();
                List<ProjectViewModel> list = JsonConvert.DeserializeObject<List<ProjectViewModel>>(Result);

                return View("ViewProjects", list);
            }
            catch (Exception e)
            {
                return Content("" + e);
            }
        }
        public ActionResult Add()
        {
            var item = new ProjectViewModel();
            item.Employees = new SelectList(objEmployeeService.DisplayDesignation(), "EmployeeId", "EmployeeName", "EmployeeDesignation");
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(true)]
        public ActionResult Add(ProjectViewModel item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Project = new Project()
                    {
                        ProjectId = item.ProjectId,
                        ProjectTitle = item.ProjectTitle,
                        ProjectStartDate = item.ProjectStartDate,
                        ProjectEndDate = item.ProjectEndDate,
                        EmployeeId = item.EmployeeId
                    };
                    var Added = objProjectService.AddProject(Project);
                    if (Added)
                    {
                        return RedirectToAction("ViewProjects");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to add");
                        return View(item);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "One or More validation failed");
                    return View(item);
                }
            }
            catch (ProjectManagerException e)
            {
                return Content("Error" + e.Message);
            }
        }
    }
}