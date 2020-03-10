using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using olShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace olShop.Data.EF.EFContext
{
    public class DbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
