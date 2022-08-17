using Updated_Task_Manager.Data;

namespace Updated_Task_Manager.ViewModels.Charts
{
    public class ChartsVM
    {
        ToDoDbContext db;
        public ChartsVM(ToDoDbContext _db)
        {
            db = _db;

        }

    }

}
