using System.Web.Http;
using System.Web.Http.Cors;
using ProjectManager.BL;
using ProjectManager.Entities;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.DAL;

namespace ProjectManager.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectManagerController : ApiController
    {

        #region Project 
        [Route("api/Project")]
        [HttpGet]
        public IHttpActionResult GetAllProject()
        {
            ManagerContext db = new ManagerContext();
            ProjectManager_BL projectManager = new ProjectManager_BL();
            List<Project> project = new List<Project>();
            project = projectManager.GetAllProject();
            var projectItem = (from p in project
                               select new
                               {
                                   ProjectId = p.ProjectId,
                                   ProjectName = p.ProjectName,
                                   Priority = p.Priority,
                                   StartDate = p.StartDate?.ToString("MM/dd/yyyy"),
                                   EndDate = p.EndDate?.ToString("MM/dd/yyyy"),
                                   UserId = p.UserId,
                                   TotalTask = (from task in db.Tasks where task.projectId == p.ProjectId select task).Count(),
                                   CompletedTask = (from task in db.Tasks where task.projectId == p.ProjectId && task.IsEnd == true select task).Count()
                               }).ToList();
            return Ok(projectItem);
        }

        [Route("api/Project/{Id}")]
        [HttpGet]
        public IHttpActionResult GetProjectById(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            return Ok(projectManager.GetProjectById(Id));
        }

        [Route("api/Project/AddProject")]
        [HttpPost]
        public IHttpActionResult AddProject(Project project)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.AddProject(project);
            return Ok("New Project Added successfully");
        }

        [Route("api/Project/UpdateProject")]
        [HttpPut]
        public IHttpActionResult EditProject(Project project)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.UpdateProject(project);
            return Ok("Project is Updated successfully");
        }

        [Route("api/Project/DeleteProject/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProject(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.DeleteProjectById(Id);
            return Ok("Project is Deleted successfully");
        }
        #endregion

        #region Task
        [Route("api/Task")]
        [HttpGet]
        public IHttpActionResult GetAllTask()
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            return Ok(projectManager.GetAllTask());
        }

        [Route("api/Task/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            var Task = projectManager.GetTaskById(Id);

            var TaskItem = new
            {
                TaskId = Task.TaskId,
                TaskName = Task.TaskName,
                Priority = Task.Priority,
                StartDate = Task.StartDate.ToString("yyyy-MM-dd"),
                EndDate = Task.EndDate.ToString("yyyy-MM-dd"),
                ParentTaskId = Task.ParentTaskId,
                IsParent = Task.IsParent,
                IsEnd = Task.IsEnd,
                ProjectId = Task.projectId,
                UserId = Task.UserId
            };
            return Ok(TaskItem);
        }


        [Route("api/Task/AddTask")]
        [HttpPost]
        public IHttpActionResult AddTask(Task task)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.AddTask(task);
            return Ok("New Task Added successfully");
        }

        [Route("api/Task/UpdateTask")]
        [HttpPut]
        public IHttpActionResult EditTask(Task task)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.UpdateTask(task);
            return Ok("Task is Updated successfully");
        }


        [Route("api/Task/DeleteTask/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.DeleteTaskById(Id);
            return Ok("Task is Deleted successfully");
        }

        [Route("api/Task/EndTask/{Id}")]
        [HttpPut]
        public IHttpActionResult EndTask(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.EndTask(Id);
            return Ok("Task is Ended successfully");
        }

        [Route("api/Task/ParentTask")]
        [HttpGet]
        public IHttpActionResult GetParentTask()
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            return Ok(projectManager.GetParentTask());
        }

        [Route("api/Task/GetTaskByProjectId/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTaskByProjectId(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            var projectTask = projectManager.GetTaskByProjectId(Id);

            var task = (from t in projectTask
                        select new
                        {
                            TaskId = t.TaskId,
                            TaskName = t.TaskName,
                            Priority = t.Priority,
                            StartDate = t.StartDate,
                            EndDate = t.EndDate,
                            ParentTaskName = (t.IsParent == false) ? projectTask.Where(p => p.ParentTaskId == t.ParentTaskId).First().TaskName : "",
                            EndTask = t.IsEnd,
                            IsParent = t.IsParent,
                            ParentTaskId = t.ParentTaskId
                        }).ToList();
            return Ok(task);
        }

        #endregion

        #region User

        [HttpGet]
        [Route("api/User")]
        public IHttpActionResult GetAllUser()
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            return Ok(projectManager.GetAllUsers());
        }

        [Route("api/User/{Id}")]
        [HttpGet]
        public IHttpActionResult GetUserById(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            return Ok(projectManager.GetUserById(Id));
        }

        [Route("api/User/AddUser")]
        [HttpPost]
        public IHttpActionResult POST(User user)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.AddUsers(user);
            return Ok("New User Added successfully");
        }

        [Route("api/User/UpdateUser")]
        [HttpPut] 
        public IHttpActionResult UpdateUser(User user)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.UpdateUser(user);
            return Ok("User is Updated successfully");
        }

        [Route("api/User/DeleteUser/{Id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int Id)
        {
            ProjectManager_BL projectManager = new ProjectManager_BL();
            projectManager.DeleteUsersById(Id);
            return Ok("User is Deleted successfully");
        }
        #endregion 
    }
}
