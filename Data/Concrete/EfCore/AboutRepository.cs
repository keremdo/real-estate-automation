using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cennet_Emlak.Data.Abstract;
using Cennet_Emlak.Entities;

namespace Cennet_Emlak.Data.Concrete.EfCore
{
    public class AboutRepository : IAboutRepository
    {
        private readonly EfEstateContext _context;
        public AboutRepository(EfEstateContext context)
        {
            _context = context;
        }
        public IQueryable<About> Values => _context.Abouts;

        public void Create(About entity)
        {
            _context.Abouts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Abouts.FirstOrDefault(m => m.AboutId == id);
            if(entity != null)
            {
                _context.Abouts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Update(About entity)
        {
            _context.Abouts.Update(entity);
            _context.SaveChanges();
        }
    }
}