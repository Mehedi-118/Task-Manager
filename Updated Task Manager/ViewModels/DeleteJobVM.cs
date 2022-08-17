using System.ComponentModel.DataAnnotations;
using Updated_Task_Manager.Models;

namespace Updated_Task_Manager.ViewModels
{
    public class DeleteJobVM
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = "Others";
        public string Details { get; set; } = "UKWN";
        public string Priority { get; set; } = "Normal";
        public DateTime TaskStartDateTime { get; set; }
        public DateTime TaskEndDateTime { get; set; }
        //public int UserId { get; set; }
        public int CategoryId { get; set; }


    }
}
