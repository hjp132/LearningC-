using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPieReviewRepository _reviewRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, IPieReviewRepository reviewRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
            _reviewRepository = reviewRepository;
        }

        // GET: /<controller>/
        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";

        //    //return View(_pieRepository.AllPies);
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRepository.AllPies;

        //    piesListViewModel.CurrentCategory = "Cheese cakes";
        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }


        public IActionResult Details(int id, string sortOrder)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            var model = new PiesItemViewModel()
            {
                PieId = pie.PieId,
                Name = pie.Name,
                ShortDescription = pie.ShortDescription,
                LongDescription = pie.LongDescription,
                AllergyInformation = pie.AllergyInformation,
                Price = pie.Price,
                ImageFileToDisplay = pie.ImageFileToDisplay,
                IsPieOfTheWeek = pie.IsPieOfTheWeek,
                InStock = pie.InStock,
                ReviewScore = pie.ReviewScore
            
            };
            model.Reviews = _reviewRepository.GetReviewsByPieId(pie.PieId)
                .Select(x => new ReviewViewModel
                {
                    id = x.id,
                    Title = x.Title,
                    Rating = x.Rating,
                    Description = x.Description,
                    PieId = x.PieId
                }).ToList();

            
            var contentlist = model.Reviews;
            ViewData["ScoreSortDesc"] = String.IsNullOrEmpty(sortOrder) ? "score_desc" : "";
            ViewData["ScoreSortAsc"] = sortOrder == "Ascending" ? "score_asc" : "Ascending";
            switch (sortOrder)
            {
                case "score_desc": model.Reviews = (List<ReviewViewModel>)contentlist.OrderByDescending(x => x.Rating).ToList();
                        break;
                case "score_asc": model.Reviews = (List<ReviewViewModel>)contentlist.OrderBy(x => x.Rating).ToList();
                    break;
            }

            
             


            return View(model);
        }

        [HttpGet]
        public IActionResult CreateReview(int pieid)
        {
            var model = new ReviewViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateReview(ReviewViewModel review, int pieid, int rating)
        {

            
            var model = new Models.PieReview()
            {
                Title = review.Title,
                Rating = review.Rating,
                Description = review.Description,
                PieId = review.PieId
            };

            if (ModelState.IsValid)
            {
                _reviewRepository.Add(model);
                return RedirectToAction("Details", "Pie", new { id = model.PieId });
            }

            return RedirectToAction("CreateReview", "Pie", new { id = model.PieId });
        }
    }
}
