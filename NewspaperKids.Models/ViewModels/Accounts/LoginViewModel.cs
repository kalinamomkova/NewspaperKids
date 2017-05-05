namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "������������� ���")]
        //[EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [Display(Name = "������� ��?")]
        public bool RememberMe { get; set; }
    }
}