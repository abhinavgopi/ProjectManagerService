using ProjectManager.DAL;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.BL
{
    public class ProjectManager_BL
    {
        #region Users API
        public List<User> GetAllUsers()
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.User.ToList();
            }
        }

        public void AddUsers(User user)
        {
            using (ManagerContext db = new ManagerContext())
            {
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public User GetUserById(int userId)
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.User.FirstOrDefault(a => a.UserId == userId);
            }
        }

        public void DeleteUsersById(int userId)
        {
            using (ManagerContext db = new ManagerContext())
            {
                User user = db.User.Find(userId);
                db.User.Remove(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (ManagerContext db = new ManagerContext())
            {
                var Item = db.User.FirstOrDefault(a => a.UserId == user.UserId);
                Item.FirstName = user.FirstName;
                Item.LastName = user.LastName;
                Item.EmployeeId = user.EmployeeId;
                db.SaveChanges();
            }
        }
        #endregion

        #region Project API
        public List<Project> GetAllProject()
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Project.ToList();
            }
        }
        public void AddProject(Project project)
        {
            using (ManagerContext db = new ManagerContext())
            {
                db.Project.Add(project);
                db.SaveChanges();
            }
        }

        public Project GetProjectById(int projectId)
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Project.FirstOrDefault(a => a.ProjectId == projectId);
            }
        }

        public Project GetProjectByName(string projectName)
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Project.FirstOrDefault(a => a.ProjectName == projectName);
            }
        }

        public void DeleteProjectById(int Id)
        {
            using (ManagerContext db = new ManagerContext())
            {
                Project project = db.Project.Find(Id);
                db.Project.Remove(project);
                db.SaveChanges();
            }
        }

        public Project UpdateProject(Project project)
        {
            using (ManagerContext db = new ManagerContext())
            {
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return project;
            }
        }
        #endregion

        #region Task API
        public List<Task> GetAllTask()
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Tasks.ToList();
            }
        }

        public void AddTask(Task task)
        {
            using (ManagerContext db = new ManagerContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        public Task GetTaskById(int Id)
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Tasks.FirstOrDefault(a => a.TaskId == Id);
            }
        }

        public Task GetTaskByName(string taskName)
        {
            using (ManagerContext db = new ManagerContext())
            {
                return db.Tasks.FirstOrDefault(n => n.TaskName == taskName);
            }
        }

        public void DeleteTaskById(int Id)
        {
            using (ManagerContext db = new ManagerContext())
            {
                Task task = db.Tasks.Find(Id);
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }

        public Task UpdateTask(Task task)
        {
            using (ManagerContext db = new ManagerContext())
            {
                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return task;
            }
        }

        public void EndTask(int Id)
        {
            using (ManagerContext db = new ManagerContext())
            {
                Task task = db.Tasks.FirstOrDefault(g => g.TaskId == Id);
                task.IsEnd = true;
                task.EndDate = DateTime.Now;
                db.SaveChanges();
            }
        }

        public List<Task> GetParentTask()
        {
            using (ManagerContext db = new ManagerContext())
            {
                List<Task> Task = db.Tasks.Where(a => a.IsParent).ToList();
                return Task;
            }
        }

        public List<Task> GetTaskByProjectId(int projectId)
        {
            using (ManagerContext db = new ManagerContext())
            {
                List<Task> Task = db.Tasks.Where(a => a.projectId == projectId).ToList();
                return Task;
            }
        }
        #endregion
    }
}
