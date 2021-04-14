using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QrantApplicationForm.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QrantApplicationForm.Models.DAL
{
    public class MyContext :IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
