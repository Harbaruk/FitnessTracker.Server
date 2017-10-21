using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class UserProfileController : ApiControllerBase
    {
        private readonly IUserProfileOperations _profileOperations;

        public UserProfileController(IUserProfileOperations userProfileOper, ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _profileOperations = userProfileOper;
        }

        [Route("profile")]
        [AuthorizeIfTokenValid]
        [HttpGet]
        public IHttpActionResult GetProfile()
        {
            try
            {
                return Ok(_profileOperations.GetProfile(_currentUserProvider.CurrentUserId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("profile")]
        [AuthorizeIfTokenValid]
        [HttpPut]
        public IHttpActionResult UpdateProfile(UserProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _profileOperations.UpdateProfile(model, _currentUserProvider.CurrentUserId);
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
