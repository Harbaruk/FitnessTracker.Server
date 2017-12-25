using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class BlockController : ApiControllerBase
    {
        private readonly IBlockOperations _blockOperations;

        public BlockController(IBlockOperations blockOper, ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _blockOperations = blockOper;
        }

        [Route("plan/{plan:int}")]
        [HttpGet]
        [AuthorizeIfTokenValid]
        public IHttpActionResult GetBlocks(int plan)
        {
            try
            {
                return Ok(_blockOperations.GetBlocks(plan, _currentUserProvider.CurrentUserId));
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
                _blockOperations.CreateBlock(model, _currentUserProvider.CurrentUserId);
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
                _blockOperations.UpdateBlock(model, _currentUserProvider.CurrentUserId);
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