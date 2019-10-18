using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using ProjectManagerUI.ViewModels;
using Exceptions;
using ProjectManagerDAL;
using ProjectmanagerBLL;

namespace ProjectManagerUI.Controllers
{
    [HandleError]
    public class TaskController : Controller
    {
        TaskService TaskServ = null;

        public TaskController()
        {
            TaskServ = new TaskService();
        }

        // GET: Task
        public ActionResult Index()
        {
            return View("Home");
        }
        public ActionResult ViewTasks()
        {
            try
            {
                var objTaskService = new TaskService();
                var list = objTaskService.Display();
                var ViewList = new List<TaskViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new TaskViewModel() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskEndDate = item.TaskEndDate, TaskStatus = item.TaskStatus, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId });
                }
                return View("ViewTasks", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("" + e);
            }
        }

        public ActionResult ViewPendingTasks()
        {
            try
            {
                var objTaskService = new TaskService();
                var list = objTaskService.DisplayPending();
                var ViewList = new List<TaskViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new TaskViewModel() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskEndDate = item.TaskEndDate, TaskStatus = item.TaskStatus, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId });
                }
                return PartialView("_ViewPendingTasks", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("" + e);
            }
        }
        public ActionResult ViewCompletedTasks()
        {
            try
            {
                var objTaskService = new TaskService();
                var list = objTaskService.DisplayCompleted();
                var ViewList = new List<TaskViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new TaskViewModel() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskEndDate = item.TaskEndDate, TaskStatus = item.TaskStatus, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId });
                }
                return PartialView("_ViewCompletedTasks", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("" + e);
            }
        }
        public ActionResult ViewTotalTasks()
        {
            try
            {
                var objTaskService = new TaskService();
                var list = objTaskService.DisplayTotalTask();
                var ViewList = new List<TaskViewModel>();
                foreach (var item in list)
                {
                    ViewList.Add(new TaskViewModel() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskEndDate = item.TaskEndDate, TaskStatus = item.TaskStatus, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId });
                }
                return PartialView("_ViewTotalTasks", ViewList);
            }
            catch (ProjectManagerException e)
            {
                return Content("" + e);
            }
        }
        public ActionResult AddTask()
        {
            var item = new TaskViewModel();
            item.Employees = new SelectList(TaskServ.Displaypendingtasks(), "EmployeeId", "EmployeeName", "EmployeeDesignation");
            return View(item);
        }



        [HttpPost]
        public ActionResult AddTask(TaskViewModel item)
        {
            TaskN task = new TaskN() { TaskId = item.TaskId, TaskName = item.TaskName, TaskDescription = item.TaskDescription, TaskStartDate = item.TaskStartDate, TaskPriority = item.TaskPriority, TaskStatus = item.TaskStatus, TaskEndDate = item.TaskEndDate, ProjectId = item.ProjectId, EmployeeId = item.EmployeeId };
            try
            {
                var objTaskService = new TaskService();
                if (objTaskService.AddTask(task))
                {
                    return RedirectToAction("ViewProjects");
                }
                return Content("Cannot Add Task");
            }
            catch (ProjectManagerException e)
            {
                throw;
            }
        }
    }
}