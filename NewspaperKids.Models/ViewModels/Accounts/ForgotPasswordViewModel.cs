namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "�����")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "������������� ���")]
        public string UserName { get; set; }
    }
}