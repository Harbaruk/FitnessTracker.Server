using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using System;
using System.Web.Http;

namespace FitnessTracker.WebAPI.Controllers
{
    [RoutePrefix("home")]
    public class FitnessController : ApiController
    {
        private readonly IFitnessOperations _fitnessOperations;

        public FitnessController(IFitnessOperations fitnessOper)
        {
            _fitnessOperations = fitnessOper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get_all")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_fitnessOperations.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("add")]
        public IHttpActionResult Add(PostFitnessModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _fitnessOperations.Add(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("update")]
        public IHttpActionResult Update(FitnessModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _fitnessOperations.Update(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _fitnessOperations.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

    }
}
