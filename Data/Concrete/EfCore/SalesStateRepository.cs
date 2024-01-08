using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class SalesStateRpository : ISalesStateRepository
    {
        private readonly EfEstateContext _context;
        public SalesStateRpository(EfEstateContext context)
        {
            _context =context;
        }

        public IQueryable<SalesState> SalesStates => _context.SalesStates;
    }
}