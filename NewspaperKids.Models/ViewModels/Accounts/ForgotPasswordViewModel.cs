namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Емейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}