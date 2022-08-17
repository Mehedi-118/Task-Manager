using System.ComponentModel.DataAnnotations;

namespace Updated_Task_Manager.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email Can't be Empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Can't be Empty")]
        public string Password { get; set; }
    }
}
