using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMessenger.Models
{
    public class BaseContext : IdentityDbContext<Student>
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
           
        }
        public DbSet<Work> Works { get; set; }

       // public DbSet<Student> Students { get; set; }

       
    }
}
