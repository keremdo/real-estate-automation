using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class EfEstateContext : DbContext
    {
        public EfEstateContext(DbContextOptions<EfEstateContext> options):base(options)
        {
            
        }
        public DbSet<About> Abouts {get;set;}
        public DbSet<Portfolio> Portfolios {get;set;}
        public DbSet<StartPage> StartPages {get;set;}
        public DbSet<Message> Messages {get;set;}
        public DbSet<SalesState> SalesStates {get;set;}

    }
}