﻿using Exceptions;
using ProjectManagerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ProjectmanagerBLL
{
    public class TaskService
    {
        static TaskNRepository TaskRepo = null;
        public TaskService()
        {
            TaskRepo = new TaskNRepository();
        }
        public List<TaskN> Display()
        {
            try
            {
                return TaskRepo.Display().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }
        public bool AddTask(TaskN proj)
        {
            try
            {
                return TaskRepo.Add(proj);
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public List<TaskN> DisplayPending()
        {
            try
            {
                return TaskRepo.GetPendingTasks().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public List<TaskN> DisplayCompleted()
        {
            try
            {
                return TaskRepo.GetCompletedTasks().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }

        public List<TaskN> DisplayTotalTask()
        {
            try
            {
                return TaskRepo.GetTotalTasks().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }


        public List<TaskN> GetTasks(int projectId)
        {

            try
            {
                return TaskRepo.GetTasks(projectId);
            }
            catch (Exception ex)
            {
                throw new ProjectManagerException("Error finding Task" + ex);
            }
        }
        public List<Employee> Displaypendingtasks()
        {
            try
            {
                return TaskRepo.Displaypendingtasks().ToList();
            }
            catch (ProjectManagerException e)
            {
                throw e;
            }
        }


    }
}