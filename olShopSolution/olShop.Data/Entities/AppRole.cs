using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace olShop.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base()
        {

        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
