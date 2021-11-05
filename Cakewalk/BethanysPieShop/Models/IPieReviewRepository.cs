using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieReviewRepository
    {
        IEnumerable<PieReview> GetAll { get; }
        IEnumerable<PieReview> GetReviewsByPieId(int PieId);
        void Add(PieReview review);
        void Delete(int id);
    }
}
