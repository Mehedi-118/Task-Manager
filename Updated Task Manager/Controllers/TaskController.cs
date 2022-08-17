using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Updated_Task_Manager.Data;
using Updated_Task_Manager.Models;
using Updated_Task_Manager.ViewModels;

namespace Updated_Task_Manager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ToDoDbContext db;
        public TaskController(ToDoDbContext _db)
        {
            db = _db;
        }
        public IActionResult List(int CategoryId, int pg = 1)
        {
            if (CategoryId == 0)
            {
                ///Get CategoryId From Edit /Delete [HttpPost]
                 CategoryId = (int)TempData["CategoryId"];
            }
            
           
            int workTasksCount = 0;
            if (CategoryId == 1)
            {
                IEnumerable<Job> tasksList = db.Tasks
                            .Include(c => c.Category)
                            .Where(c => c.Category.CategoryName == "Work" &&
                                c.UserId == HttpContext.Session.GetInt32("userId"));
                ViewData["Title"] = "Work";
                workTasksCount = tasksList.Count();
                const int pageSize = 4;
                if (pg < 1)
                    pg = 1;
                var pager = new Pager(workTasksCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = tasksList.Skip(recSkip).Take(pager.PageSize).ToList();
                ViewBag.Pager = pager;
                TempData["CategoryId"] = CategoryId;
                ViewBag.TotalTaskCount = workTasksCount;
                return View(data);
            }
            else if (CategoryId == 2)
            {
                IEnumerable<Job> tasksList = db.Tasks
                            .Include(c => c.Category)
                            .Where(c => c.Category.CategoryName == "Personal" &&
                                    c.UserId == HttpContext.Session.GetInt32("userId"));
                ViewData["Title"] = "Personal";
                workTasksCount = tasksList.Count();
                const int pageSize = 4;
                if (pg < 1)
                    pg = 1;
                var pager = new Pager(workTasksCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = tasksList.Skip(recSkip).Take(pager.PageSize).ToList();
                ViewBag.Pager = pager;
                TempData["CategoryId"] = CategoryId;
                ViewBag.TotalTaskCount = workTasksCount;
                return View(data);

            }
            else if (CategoryId == 3)
            {
                IEnumerable<Job> tasksList = db.Tasks
                            .Include(c => c.Category)
                            .Where(c => c.Category.CategoryName == "Shopping" &&
                                    c.UserId == HttpContext.Session.GetInt32("userId"));
                ViewData["Title"] = "Shopping";
                workTasksCount = tasksList.Count();
                const int pageSize = 4;
                if (pg < 1)
                    pg = 1;
                var pager = new Pager(workTasksCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = tasksList.Skip(recSkip).Take(pager.PageSize).ToList();
                ViewBag.Pager = pager;
                TempData["CategoryId"] = CategoryId;
                ViewBag.TotalTaskCount = workTasksCount;
                return View(data);

            }
            else if (CategoryId == 4)
            {
                IEnumerable<Job> tasksList = db.Tasks
                            .Include(c => c.Category)
                            .Where(c => c.Category.CategoryName == "Others" &&
                                    c.UserId == HttpContext.Session.GetInt32("userId"));
                ViewData["Title"] = "Others";
                workTasksCount = tasksList.Count();
                const int pageSize = 4;
                if (pg < 1)
                    pg = 1;
                var pager = new Pager(workTasksCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = tasksList.Skip(recSkip).Take(pager.PageSize).ToList();
                ViewBag.Pager = pager;
                TempData["CategoryId"] = CategoryId;
                ViewBag.TotalTaskCount = workTasksCount;
                return View(data);
            }
            else return NotFound();
        }     
        public void GetView(int CategoryId)
        {
            if (CategoryId == 1)
            {
                List<SelectListItem> categoryList = new()
                {
                    new SelectListItem { Value = "-1", Text = "Select Work Category"},
                    new SelectListItem { Value = "1", Text = "Work",Selected=true },
                    new SelectListItem { Value = "2", Text = "Personal" },
                    new SelectListItem { Value = "3", Text = "Shopping" },
                    new SelectListItem { Value = "4", Text = "Others" },

                };
                ViewBag.categories = categoryList;
            }
            else if (CategoryId == 2)
            {
                List<SelectListItem> categoryList = new()
                {
                    new SelectListItem { Value = "-1", Text = "Select Work Category"},
                    new SelectListItem { Value = "1", Text = "Work" },
                    new SelectListItem { Value = "2", Text = "Personal",Selected=true },
                    new SelectListItem { Value = "3", Text = "Shopping" },
                    new SelectListItem { Value = "4", Text = "Others" },

                };
                ViewBag.categories = categoryList;
            }
            else if (CategoryId == 3)
            {
                List<SelectListItem> categoryList = new()
                {
                    new SelectListItem { Value = "-1", Text = "Select Work Category"},
                    new SelectListItem { Value = "1", Text = "Work" },
                    new SelectListItem { Value = "2", Text = "Personal" },
                    new SelectListItem { Value = "3", Text = "Shopping" ,Selected=true},
                    new SelectListItem { Value = "4", Text = "Others" },

                };
                ViewBag.categories = categoryList;
            }
            else if (CategoryId == 4)
            {
                List<SelectListItem> categoryList = new()
                {
                    new SelectListItem { Value = "-1", Text = "Select Work Category"},
                    new SelectListItem { Value = "1", Text = "Work" },
                    new SelectListItem { Value = "2", Text = "Personal" },
                    new SelectListItem { Value = "3", Text = "Shopping" },
                    new SelectListItem { Value = "4", Text = "Others" ,Selected=true},

                };
                ViewBag.categories = categoryList;
            }
            List<string> priorityList = new List<string>()
            {
                "Critical",
                "Medium",
                "Normal"
            };
            ViewBag.priorityListGet = priorityList;

        }
        public IActionResult Create(int CategoryId)
        {
            TempData["CategoryId"] = CategoryId;
            GetView(CategoryId);
            return View();
        }
        public IActionResult CreateFromHome()
        {
            List<SelectListItem> categoryList = new()
                {
                    new SelectListItem { Value = "-1", Text = "Select Work Category",Selected=true },
                    new SelectListItem { Value = "1", Text = "Work"},
                    new SelectListItem { Value = "2", Text = "Personal" },
                    new SelectListItem { Value = "3", Text = "Shopping" },
                    new SelectListItem { Value = "4", Text = "Others" },

                };
            ViewBag.categories = categoryList;
            List<string> priorityList = new List<string>()
            {
                "Critical",
                "Medium",
                "Normal"
            };
            ViewBag.priorityListGet = priorityList;
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(AddJobVM model,int CategoryId)
        {
            TempData["CategoryId"] = CategoryId;
            GetView(CategoryId);
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId != null)
            {
                if (ModelState.IsValid)
                {
                    var job = new Job()
                    {
                        Title = model.Title,
                        Details = model.Details,
                        TaskStartDateTime = model.TaskStartDateTime,
                        TaskEndDateTime = model.TaskEndDateTime,
                        Priority = model.Priority,
                        CategoryId = model.CategoryId,
                        UserId = (int)userId

                    };
                    db.Tasks.Add(job);
                    if (db.SaveChanges() > 0)
                    {
                        ModelState.Clear();
                        return View();
                    }

                }
                else
                    return View();
            }
            return RedirectToAction("LogIn", "Account");
        }


        public IActionResult Edit(int jobId,int CategoryId)
        {

            TempData["CategoryId"] = CategoryId;
            var result = db.Tasks.Find(jobId);
            if (result != null) {
                var task = new EditJobVM()
                {
                    
                    Title = result.Title,
                    Details = result.Details,
                    Priority = result.Priority,
                    TaskStartDateTime = result.TaskStartDateTime,
                    TaskEndDateTime = result.TaskEndDateTime,
                    CategoryId = result.CategoryId,
                   
                };
                ViewBag.jobId = jobId;
                GetView(CategoryId);
                return View(task);
            }
            return NotFound();       
        }
        [HttpPost]
        public IActionResult Edit(EditJobVM model,int jobId,int CategoryId)
        {
            
            if (ModelState.IsValid)
            {
                TempData["CategoryId"] =CategoryId;
                var editJob = new Job()
                {
                    Id= jobId,
                    Title = model.Title,
                    Details = model.Details,
                    TaskStartDateTime = model.TaskStartDateTime,
                    TaskEndDateTime = model.TaskEndDateTime,
                    Priority = model.Priority,
                    UserId = (int)HttpContext.Session.GetInt32("userId"),
                    CategoryId=model.CategoryId
                };
                db.Tasks.Update(editJob);
                if (db.SaveChanges() > 0)
                    return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Delete(int jobId, int CategoryId)
        {

            TempData["CategoryId"] = CategoryId;
            var result = db.Tasks.Find(jobId);
            if (result != null)
            {
                var task = new DeleteJobVM()
                {

                    Title = result.Title,
                    Details = result.Details,
                    Priority = result.Priority,
                    TaskStartDateTime = result.TaskStartDateTime,
                    TaskEndDateTime = result.TaskEndDateTime,
                    CategoryId = result.CategoryId,

                };
                ViewBag.jobId = jobId;
                GetView(CategoryId);
                return View(task);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(DeleteJobVM model, int jobId, int CategoryId)
        {
            TempData["CategoryId"] = CategoryId;
            var deleteJob = db.Tasks.Find(jobId);
            if (deleteJob == null)
                return NotFound();
            else {
                db.Tasks.Remove(deleteJob);
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }


        public IActionResult Status(EditJobVM model,int jobId, int CategoryId)
        {
            TempData["CategoryId"] = CategoryId;
            var job = db.Tasks.FirstOrDefault(c => c.Id == jobId);
            var statusJob = new Job()
            {
                Id = jobId,
                Title = model.Title,
                Details = model.Details,
                TaskStartDateTime = model.TaskStartDateTime,
                TaskEndDateTime = model.TaskEndDateTime,
                Priority = model.Priority,
                UserId = (int)HttpContext.Session.GetInt32("userId"),
                CategoryId = model.CategoryId,
                Status=model.Status
               
            };
            db.Tasks.Update(statusJob);
            if (db.SaveChanges() > 0)
                return RedirectToAction("List");

            return RedirectToAction("List");

        }
    }
}

