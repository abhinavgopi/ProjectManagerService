using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsEnd { get; set; }
        public bool IsParent { get; set; }
        public int? ParentTaskId { get; set; }
        public int? projectId { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }

        public Task()
        {
            IsEnd = false;
            IsParent = false;
        }
    }
}
