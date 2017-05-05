namespace NewspaperKids.Models.ViewModels.Accounts
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Емейл")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Потребителско име")]
        [MinLength(2, ErrorMessage = "Потребителското име трябва да е поне 2 символа")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Име")]
        [MinLength(3, ErrorMessage = "Името трябва да бъде дълго поне 3 символа!")]
        [RegularExpression("[а-яА-Я]+", ErrorMessage = "Името може да съдържа само букви на кирилица!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        [MinLength(3, ErrorMessage = "Фамилията трябва да бъде поне 3 символа!")]
        [RegularExpression("[а-яА-Я]+", ErrorMessage = "Фамилията може да съдържа само букви на кирилица!")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Години")]
        [Range(1, 100, ErrorMessage = "Лицето трябва да има навършена поне 1 година!")]
        public int Age { get; set; }

        public string Password { get; set; }
    }
}