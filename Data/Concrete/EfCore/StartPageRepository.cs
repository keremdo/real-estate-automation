using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class StartPageRepository : IStartPageRepository
    {
        private readonly EfEstateContext _context;
        public StartPageRepository(EfEstateContext context)
        {
            _context =context;
        }

        public IQueryable<StartPage> Values => _context.StartPages;

        public void Create(StartPage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StartPage entity)
        {
            _context.StartPages.Update(entity);
            _context.SaveChanges();
        }
    }
}