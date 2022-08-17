using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Updated_Task_Manager.Data;
using Updated_Task_Manager.Models;

namespace Updated_Task_Manager.Controllers
{
    public class ChartController : Controller
    {
        ToDoDbContext db;
        public ChartController(ToDoDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            IEnumerable<Job> tasksList = db.Tasks
                            .Include(c => c.Category)
                            .Where(c => c.TaskStartDateTime>=DateTime.Now && c.Status!="Complete" &&
                                c.UserId == HttpContext.Session.GetInt32("userId")).Take(5).ToList();
            var workTasksCount = tasksList.Count();
          
            return View(tasksList);
        }
        
        public List<object> GetTaskPerCategory()
        {
            var resultForCharts = db.Tasks.Where(u => u.UserId == 1)
                                    .GroupBy(catId => catId.CategoryId)
                                    .Select(g => new { CatId = g.Key, count = g.Count() })
                                    .OrderByDescending(k => k.count)
                                    .Join(db.Categories, s => s.CatId, j => j.Id, (s, j) => new { s.count, j.CategoryName });
            List<object> data = new List<object>();
            List<string> labels = resultForCharts.Select(l => l.CategoryName).ToList();
            data.Add(labels);
            List<int> taskCount = resultForCharts.Select(t => t.count).ToList();
            data.Add(taskCount);
            return data;
        } 
        public List<object> GetTaskPerPriority()
        {
            var resultForCharts = db.Tasks.Where(u => u.UserId == 1)
                                    .GroupBy(priority => priority.Priority)
                                    .Select(g => new { CatId = g.Key, count = g.Count() })
                                    .OrderByDescending(k => k.count);
                                    
            List<object> data = new List<object>();
            List<string> labels = resultForCharts.Select(l => l.CatId).ToList();
            data.Add(labels);
            List<int> taskCount = resultForCharts.Select(t => t.count).ToList();
            data.Add(taskCount);
            return data;
        }
    }
}
