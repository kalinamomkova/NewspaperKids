namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "�����")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "������������� ���")]
        [MinLength(2, ErrorMessage = "��������������� ��� ������ �� � ���� 2 �������")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "���")]
        [MinLength(3, ErrorMessage = "����� ������ �� ���� ����� ���� 3 �������!")]
        [RegularExpression("[�-��-�]+", ErrorMessage = "����� ���� �� ������� ���� ����� �� ��������!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "�������")]
        [MinLength(3, ErrorMessage = "��������� ������ �� ���� ���� 3 �������!")]
        [RegularExpression("[�-��-�]+", ErrorMessage = "��������� ���� �� ������� ���� ����� �� ��������!")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "������")]
        [Range(1, 100, ErrorMessage = "������ ������ �� ��� ��������� ���� 1 ������!")]
        public int Age { get; set; }

        public string Password { get; set; }
    }
}