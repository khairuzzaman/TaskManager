using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.OData;
using System.Web.OData.Query;
using TaskManagement.Core;
using TaskManagement.Core.DomainEntity;
using TaskManagement.Service.DomainService;
using TaskManagement.Web.Helpers;

namespace TaskManagement.Web.Controllers
{
    public class IterationController : ODataController
    {
        IIterationOrSprintService _iterationService;

        public IterationController(IIterationOrSprintService iterationService)
        {
            _iterationService = iterationService;
        }
        
        [EnableQuery(PageSize= 25,AllowedQueryOptions=AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Get()
        {
            var iterations = await _iterationService.GetAll();
            return Ok(iterations);
        }

        [EnableQuery(AllowedQueryOptions=AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var iteration = await _iterationService.GetById(key);
            if(iteration == null)
            {
                throw  ExceptionHelpers.ResourceNotFoundError(Request);
            }
            return Ok(iteration);
        }

        [System.Web.Mvc.HttpPost]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Post(IterationOrSprint entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _iterationService.Create(entity);
            return Created(entity);
        }

        [System.Web.Mvc.HttpPut]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Put([FromODataUri] int key, IterationOrSprint entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != entity.Id)
            {
                return BadRequest();
            }
            await _iterationService.Update(entity);

            return Updated(entity);
        }
        
        
        [System.Web.Mvc.HttpPatch]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<IterationOrSprint> delta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var iteration = await _iterationService.GetById(key);//_db.ContactType.Single(t => t.ContactTypeID == key);
            
            //_db.SaveChanges();
            using(var ctx = new TaskManagementContext())
            {
                var iteration = ctx.IterationOrSprints.SingleOrDefault(x => x.Id == key);
                delta.Patch(iteration);
                await ctx.SaveChangesAsync();
                return Updated(iteration);
            }
            
        }

        [System.Web.Mvc.HttpDelete]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var entityInDb = await _iterationService.GetById(key);//_db.ContactType.SingleOrDefault(t => t.ContactTypeID == key);

            await _iterationService.Delete(entityInDb);
            
            return Content(HttpStatusCode.NoContent, "Deleted");
        }


    }
}