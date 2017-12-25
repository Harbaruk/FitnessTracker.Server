using FitnessTracker.WebApi.Providers.Abstraction;
using FitnessTracker.WebApi.Filters;
using FitnessTracker.Operations.Abstraction;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [AuthorizeIfAdmin]
    public class AdminController : ApiControllerBase
    {
        private IAdminOperations _adminOperations;

        public AdminController(IAdminOperations adminOperations, ICurrentUserProvider currentUserProvider) : base(currentUserProvider)
        {
            _adminOperations = adminOperations;
        }

        [HttpGet]
        [Route("admin/users")]
        public IHttpActionResult GetUsers(int skip = 0, int take = 10)
        {
            try
            {
                return Ok(_adminOperations.GetUsers(skip, take));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}