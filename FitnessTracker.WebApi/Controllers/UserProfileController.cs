using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Web;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("user")]
    public class UserProfileController : ApiControllerBase
    {
        private readonly IUserProfileOperations _profileOperations;
        private readonly IUrlProvider _urlProvider;

        public UserProfileController(IUserProfileOperations userProfileOper,
            IUrlProvider urlProvider,
            ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _urlProvider = urlProvider;
            _profileOperations = userProfileOper;
        }

        [Route("profile")]
        //[AuthorizeIfTokenValid]
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

        [HttpPost]
        [Route("profile/image")]
        public IHttpActionResult UpdateImage(ImageModel model)
        {
            var res = new PostImageModel
            {
                Base64 = model.Image,
                ImageUrl = _urlProvider.ImageUrl,
                Path = HttpContext.Current.Server.MapPath("~/Uploads/Images"),
            };

            _profileOperations.UpdateProfileImage(res, _currentUserProvider.CurrentUserId);
            return Ok();
        }
    }
}
