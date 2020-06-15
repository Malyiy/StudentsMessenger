using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMessenger.Models
{
    public class Work
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Дължина на заглавието трябва да е  от 5 до 100 символа")]
        [Display(Name = "Заглавие")]
        public string Titlework { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        public string Link { get; set; }
        public byte[] FileBytes { get; set; }

        
        public string FileType { get; set; }

        

    }
}
