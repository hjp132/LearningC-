using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace BethanysPieShop.Controllers
{
    public class ReivewController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IPieReviewRepository _reviewRepository;


        public ReivewController(IPieRepository pieRepository, IPieReviewRepository reviewRepository)
        {
            _pieRepository = pieRepository;
            _reviewRepository = reviewRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new ReviewViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ReviewViewModel review)
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
                return RedirectToAction("Details", "Details", new { id = model.PieId });
            }

            return View();
        }

    }
}
