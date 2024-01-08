using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Concrete.EfCore;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Data.Abstract
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
        
    }
}