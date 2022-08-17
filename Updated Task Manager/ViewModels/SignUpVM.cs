using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Updated_Task_Manager.Models;

namespace Updated_Task_Manager.ViewModels
{
    public class SignUpVM
    {
        
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password & Confirm Password doesn't match")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }


        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        public bool IsRemembered { get; set; } = false;

    }
}
