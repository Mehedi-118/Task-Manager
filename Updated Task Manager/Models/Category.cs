using System.ComponentModel.DataAnnotations;

namespace Updated_Task_Manager.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; } = "Others";
        //public IList<Job> Tasks { get; set; }
        ////public int MyProperty { get; set; }

        //public int? TaskId { get; set; }
        
    }
}
