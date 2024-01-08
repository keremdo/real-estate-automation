using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly EfEstateContext _context;
        public PortfolioRepository(EfEstateContext context)
        {
            _context = context;
        }
        public IQueryable<Portfolio> Values => _context.Portfolios;

        public void Create(Portfolio entity)
        {
            _context.Portfolios.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Portfolios.FirstOrDefault(m => m.PortfolioId == id);
            if(entity != null)
            {
                _context.Portfolios.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(Portfolio entity)
        {
            _context.Portfolios.Update(entity);
            _context.SaveChanges();
        }

    }
}