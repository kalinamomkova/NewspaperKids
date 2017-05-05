namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        //[EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}