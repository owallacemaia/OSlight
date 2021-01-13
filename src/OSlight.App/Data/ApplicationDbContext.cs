using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OSlight.App.ViewModels;

namespace OSlight.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OSlight.App.ViewModels.AbrirOSViewModel> AbrirOSViewModel { get; set; }
        public DbSet<OSlight.App.ViewModels.FecharOSViewModel> FecharOSViewModel { get; set; }
    }
}
