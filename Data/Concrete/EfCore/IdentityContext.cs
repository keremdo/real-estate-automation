using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class IdentityContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {
            
        }
    }
}