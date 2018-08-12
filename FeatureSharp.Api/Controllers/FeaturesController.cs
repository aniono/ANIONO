using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureSharp.Data;
using FeatureSharp.Models;
using FeatureSharp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeatureSharp.Api.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController : Controller
    {
        private readonly FeatureSharpDbContext dbContext;
        private readonly IFeatureService featureService;

        public FeaturesController(FeatureSharpDbContext dbContext, IFeatureService featureService)
        {
            this.dbContext = dbContext;
            this.featureService = featureService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Feature> Get()
        {
            return dbContext.Features.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetFeature")]
        public IActionResult Get(Guid id)
        {
            var feature = dbContext.Features.FirstOrDefault(f => f.ID == id);
            if(feature == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(feature);
        }

        // GET api/<controller>/{featureName}/user/{userId}/enabled
        [HttpGet("{featureName}/user/{userId}/enabled")]
        public IActionResult Get(string featureName, Guid userId)
        {
            bool enabled = featureService.IsFeatureEnabledForUser(featureName, userId);

            return new JsonResult(new {  enabled });
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Feature feature)
        {
            if (feature == null)
                return BadRequest();

            if (feature.ID == Guid.Empty)
                feature.ID = Guid.NewGuid();
            else if (dbContext.Features.Any(f => f.ID == feature.ID))
                return BadRequest($"Feature ID:{feature.ID} already exists.");

            dbContext.Features.Add(feature);
            dbContext.SaveChanges();

            return CreatedAtRoute("GetFeature", new { id = feature.ID }, feature);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Feature newFeature)
        {
            var feature = dbContext.Features.FirstOrDefault(f => f.ID == id);
            if (feature == null)
                return NotFound($"Feature ID:{id} not exists.");

            newFeature.ID = id;
            dbContext.Features.Update(newFeature);
            dbContext.SaveChanges();

            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var feature = dbContext.Features.FirstOrDefault(f => f.ID == id);
            if(feature == null)
                return NotFound($"Feature ID:{id} not exists.");

            dbContext.Features.Remove(feature);
            dbContext.SaveChanges();

            return new NoContentResult();
        }
    }
}
