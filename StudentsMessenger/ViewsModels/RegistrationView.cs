using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMessenger.ViewsModels
{
    public class RegistrationView
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; } //1

        [Required(ErrorMessage = "Задължително поле")]
        [StringLength(100, ErrorMessage = "Дължина на име трябва да е до 100 символа")]
        [Display(Name = "Име")]
        public string FName { get; set; } //2

        [Required(ErrorMessage = "Задължително поле")]
        [StringLength(100, ErrorMessage = "Дължина на фамилия трябва да е до 100 символа")]
        [Display(Name = "Фамилия")]
        public string LName { get; set; } //3


        [Display(Name = "Презимето")]
        public string MName { get; set; } //4

        [Required(ErrorMessage = "Задължително поле")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Точно 10 символа")]
        [Display(Name = "Факултетен номер")]
        public int FNum { get; set; } //5

        [Required(ErrorMessage = "Задължително поле")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Дължина на парола трябва да е  от 6 до 30 символа")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@-_*])[A-Za-z\d@-_*]{6,30}$",ErrorMessage = "Поне една малка  и голяма латински букви a-z, A - Z,поне една цифра 0 - 9,поне един специален символ('-', '_', '@', '*')")]
        [Display(Name = "Парола")]
        public string Password { get; set; } //6

        [Compare("Password")]
        [Display(Name = "Парола отново")]
        public string ConfirmPassword { get; set; } //7

        [Required(ErrorMessage = "Задължително поле")]
        [StringLength(100, ErrorMessage = "Дължина на специалност  трябва да е до 100 символа")]
        [Display(Name = "Специалност")]
        public string Specialty { get; set; } //8

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Избирете курс")]
        public string Cours { get; set; } //9

        [Required(ErrorMessage = "Задължително поле")]
        [Display(Name = "Форма на обучението")]
        public string FormOfTraning { get; set; } //10
    }
}
