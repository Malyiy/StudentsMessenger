using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace StudentsMessenger.Models
{
    public class Filezip
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
