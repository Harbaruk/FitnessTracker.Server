using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Exercises;
using FitnessTracker.DataModel.Plan;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class PlanController : ApiControllerBase
    {
        private readonly IMyPlanOperations _planOperations;

        public PlanController(IMyPlanOperations planOper, ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _planOperations = planOper;
        }

        [Route("plans")]
        [AuthorizeIfTokenValid]
        [HttpGet]
        public IHttpActionResult GetPlans()
        {
            try
            {
                return Ok(_planOperations.GetPlans(_currentUserProvider.CurrentUserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("plan")]
        [AuthorizeIfTokenValid]
        [HttpPost]
        public IHttpActionResult AddPlan(CreatePlanModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _planOperations.CreatePlan(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("exercise")]
        [AuthorizeIfTokenValid]
        [HttpPost]
        public IHttpActionResult AddExercise(PostExerciseModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _planOperations.AddExercise(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("exercise")]
        [AuthorizeIfTokenValid]
        [HttpPut]
        public IHttpActionResult UpdateExercise(UpdateExerciseModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _planOperations.UpdateExercise(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("exercise/{plan:int}/{id:int}")]
        [HttpDelete]
        [AuthorizeIfTokenValid]
        public IHttpActionResult DeleteExercise(int plan, int id)
        {
            try
            {
                _planOperations.DeleteExercise(plan, id, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("plan/{plan:int}")]
        [HttpGet]
        [AuthorizeIfTokenValid]
        public IHttpActionResult GetExercises(int plan)
        {
            try
            {
                return Ok(_planOperations.GetBlocks(plan, _currentUserProvider.CurrentUserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("plan/block")]
        [AuthorizeIfTokenValid]
        [HttpPost]
        public IHttpActionResult CreateBlock(BlockPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _planOperations.CreateBlock(model, _currentUserProvider.CurrentUserId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("plan/block")]
        [AuthorizeIfTokenValid]
        [HttpPut]
        public IHttpActionResult UpdateBlock(UpdateBlockModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _planOperations.UpdateBlock(model, _currentUserProvider.CurrentUserId);
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
