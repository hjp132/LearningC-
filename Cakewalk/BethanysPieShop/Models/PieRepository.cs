using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;


        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Pie pie)
        {
            _appDbContext.Pies.Add(pie);
            _appDbContext.SaveChanges();
        }
        
        public void Delete(int pieId)
        {
            var pie = _appDbContext.Pies.Find(pieId);
            _appDbContext.Pies.Remove(pie);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return this.GetQuery();
            }
        }

        public void Update(Pie pie)
        {
            var entry = _appDbContext.Entry(pie);
            entry.State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return this.GetQuery().Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {

            return this.GetQuery().FirstOrDefault(p => p.PieId == pieId);
            
        }

        private IQueryable<Pie> GetQuery()
        {
            return _appDbContext.Pies.Include(c => c.Category).Include(r => r.Reviews);

        }
    }
}
