using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieReviewRepository: IPieReviewRepository
    {
        private readonly AppDbContext _appDbContext;


        public PieReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(PieReview review)
        {
            _appDbContext.Reviews.Add(review);
            _appDbContext.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var review = _appDbContext.Reviews.Find(id);
            _appDbContext.Reviews.Remove(review);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<PieReview> GetAll
        {
            get
            {
                return _appDbContext.Reviews.Include(c => c.Title);
            }
        }


        public IEnumerable<PieReview> GetReviewsByPieId(int pieId)
        {
            return from r in _appDbContext.Reviews
                   where r.PieId.Equals(pieId)
                   select r;
        }
    }
}
