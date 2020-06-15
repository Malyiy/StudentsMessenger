using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMessenger.Models
{
    public class Student : IdentityUser
    {

     

        [Required]
        [StringLength(20, MinimumLength = 5)]

        override public  string   UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string FName { get; set; }

        [Required]
        [StringLength(100)]
        public string LName { get; set; }

        public string MName { get; set; }

        [Required]
        public int FNum { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        [Required]
        [Range(1, 4)]
        public string Cours { get; set; }

        public string FormOfTraning { get; set; }

        public ICollection<Work> Works { get; set; }
    }
}
