using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureSharp.Data;
using FeatureSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeatureSharp.Web.Models;
using FeatureSharp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeatureSharp.Web.Controllers
{
    public class FeaturesController : Controller
    {
        private static readonly Guid CurrentUserId = new Guid("8e3197fd-0705-494c-a4d7-262242c0aa69");

        private readonly IFeatureService featureService;
        private readonly FeatureSharpDbContext featureSharpDbContext;

        public FeaturesController(IFeatureService featureService, FeatureSharpDbContext dbContext)
        {
            this.featureService = featureService;
            this.featureSharpDbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var features = featureSharpDbContext.Features.Select(f => f.ToFeatureViewModel());
            return View(features);
        }

        // GET: /<controller>/Details/{featureId}
        public IActionResult Details(Guid id)
        {
            var feature = featureSharpDbContext.Features.SingleOrDefault(f => f.ID == id);
            if (feature == null)
                return new NotFoundObjectResult(id);

            return View(feature.ToFeatureDetailsViewModel());
        }

        // GET: /<controller>/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /<controller>/Create
        [HttpPost]
        public IActionResult Create(FeatureCreateViewModel featureEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var feature = new Feature
                {
                    ID = Guid.NewGuid(),
                    Name = featureEditViewModel.FeatureName,
                    Description = featureEditViewModel.Description,
                    Enabled = featureEditViewModel.Enabled,
                    AuthorId = CurrentUserId
                };

                featureSharpDbContext.Features.Add(feature);
                featureSharpDbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = feature.ID });
            }

            return View(featureEditViewModel);
        }

        // GET: /<controller>/Edit/{featureId}
        public IActionResult Edit(Guid id)
        {
            var feature = featureSharpDbContext.Features.SingleOrDefault(f => f.ID == id);
            if (feature == null)
                return new NotFoundObjectResult(id);

            var featureEditViewModel = feature.ToFeatureEditViewModel();

            return View(featureEditViewModel);
        }

        // POST: /<controller>/Edit/{featureId}
        [HttpPost]
        public IActionResult Edit(FeatureEditViewModel featureEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var feature = featureSharpDbContext.Features
                    .SingleOrDefault(f => f.ID == featureEditViewModel.FeatureID);

                if (feature == null)
                    return new NotFoundObjectResult(featureEditViewModel.FeatureID);

                feature.Name = featureEditViewModel.FeatureName;
                feature.Enabled = featureEditViewModel.Enabled;
                feature.Description = featureEditViewModel.Description;

                featureSharpDbContext.Features.Update(feature);
                featureSharpDbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = feature.ID });
            }

            return View(featureEditViewModel);
        }

        public IActionResult Delete(Guid id)
        {
            var feature = featureSharpDbContext.Features.SingleOrDefault(f => f.ID == id);
            if (feature == null)
                return new NotFoundObjectResult(id);

            return View(feature.ToFeatureDeleteViewModel());
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var feature = featureSharpDbContext.Features.SingleOrDefault(f => f.ID == id);
            if (feature == null)
                return new NotFoundObjectResult(id);

            featureSharpDbContext.Features.Remove(feature);
            featureSharpDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
