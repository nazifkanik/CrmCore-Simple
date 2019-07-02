using CrmCore.Core.Firma;
using CrmCore.Core.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrmCore.EF.Contexts
{
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options) : base(options)
        {
        }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<FirmaKontak> FirmaKontaklar { get; set; }

        public DbSet<Gorusme> Gorusmeler { get; set; }

    }
}