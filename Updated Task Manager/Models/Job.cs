using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Updated_Task_Manager.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Priority { get; set; } 



        public DateTime TaskCreationDate { get; set; } = DateTime.Now;
        public DateTime TaskStartDateTime { get; set; }
        public DateTime TaskEndDateTime { get; set; }
        public string? Status { get; set; } = "Pending";

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }



    }
}
