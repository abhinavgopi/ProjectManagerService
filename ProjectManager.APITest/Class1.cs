using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.DAL;
using ProjectManager.BL;
using ProjectManager.Entities;
using ProjectManager.API.Controllers;
using System.Web.Http;
using System;
using NBench;

namespace ProjectManager.APITest
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [Description("Add User")]
        public void AddUser()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            User user = new User();
            user.FirstName = "TestName";
            user.LastName = "T";
            user.EmployeeId = "T001";
            var controller = new ProjectManagerController();
            IHttpActionResult action = controller.POST(user);
            var controllerResult = action;
            Assert.IsNotNull(controllerResult);
        }

        [Test]
        [Description("Get All Users")]
        public void GetAllUser()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.GetAllUser();
            var controllerResult = result;
            Assert.IsNotNull(controllerResult);
        }

        [Test]
        [Description("Update Users")]
        public void UpdateUser()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            User user = new User();
            user.UserId = 1;
            user.FirstName = "TestTest";
            user.LastName = "TT";
            user.EmployeeId = "T002";
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.UpdateUser(user);
            string Expected = "User updated successfully";
            Assert.AreEqual(Expected.ToString(), result.ToString());
        }
        [Test]
        [Description("Delete User")]
        public void DeleteUser()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.DeleteUser(1);
            var controllerResult = result;
            Assert.IsNotNull(controllerResult);
        }

        #region Project
        [Test]
        [Description("Add Project")]
        public void AddProject()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            Project project = new Project();
            project.ProjectName = "TestProejct";
            project.ProjectId = 12;
            project.StartDate = DateTime.Now;
            project.EndDate = DateTime.Now;
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.AddProject(project);
            var controllerResult = result;
            Assert.IsNotNull(controllerResult);
        }

        [Test]
        [Description("Get All Project")]
        public void GetAllProject()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.GetAllProject();
            var controllerResult = controller;
            Assert.IsNotNull(controllerResult);
        }

        [Test]
        [Description("Update Project")]
        public void UpdateProject()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            Project project = new Project();
            project.ProjectId = 1;
            project.ProjectName = "TestProjetUpdate";
            project.Priority = 4;
            project.EndDate = DateTime.Now;
            project.StartDate = DateTime.Now;
            var controller = new ProjectManagerController();
            var action = controller.EditProject(project);
            string Expected = "Project Updated Successfully";
            Assert.AreEqual(Expected.ToString(), action.ToString());
        }

        [Test]
        [Description("Delete Project")]
        public void DeleteProject()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult action = controller.DeleteProject(1);
            var controllerResult = action;
            Assert.IsNotNull(controllerResult);
        }
        #endregion

        #region Task

        [Test]
        [Description("Get All Task")]
        public void GetAllTask()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult action = controller.GetAllTask();
            var controllerResult = action;
            Assert.IsNotNull(controllerResult);
        }

        [Test]
        [Description("Add Task")]
        public void AddTask()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            Task task = new Task();
            task.TaskName = "TestTask";
            task.projectId = 1;
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now;
            task.ParentTaskId = 1;
            task.Priority = 3;
            var controller = new ProjectManagerController();
            IHttpActionResult result = controller.AddTask(task);
            var controllerResult = result;
            Assert.IsNotNull(controllerResult);
        }


        [Test]
        [Description("Update Task")]
        public void UpdateTask()
        {
            ProjectManager_BL bl = new ProjectManager_BL();
            Task task = new Task();
            task.TaskId = 1;
            task.projectId = 1;
            task.TaskName = "TestTaskUpdate";
            task.Priority = 14;
            task.ParentTaskId = 2;
            task.EndDate = DateTime.Now;
            task.StartDate = DateTime.Now;
            var controller = new ProjectManagerController();
            var action = controller.EditTask(task);
            string Expected = "Task Updated Successfully";
            Assert.AreEqual(Expected.ToString(), action.ToString());
        }

        [Test]
        [Description("Delete Task")]
        public void DeleteTask()
        {
            var controller = new ProjectManagerController();
            IHttpActionResult action = controller.DeleteTask(1);
            var controllerResult = action;
            Assert.IsNotNull(controllerResult);
        }

        #endregion  

        private Counter counter;
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            counter = context.GetCounter("TestCounter");
        }

        [PerfBenchmark(Description = "", NumberOfIterations = 3, RunMode = RunMode.Throughput, TestMode = TestMode.Test, RunTimeMilliseconds = 1000)]
        [CounterThroughputAssertion("TestConter", MustBe.GreaterThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo,0.0d)]
        public void Benchmark()
        {
            counter.Increment();
        }

        [PerfCleanup]
        public void Cleanup()
        { }

    }
}
