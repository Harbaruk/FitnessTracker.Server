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

        [HttpDelete]
        [Route("admin/user/{id:int}")]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                _adminOperations.DeleteUser(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [Route("admin/approve_list")]
        [HttpGet]
        public IHttpActionResult GetApproveList()
        {
            try
            {
                return Ok(_adminOperations.GetApproveList());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("admin/approve/{id:int}")]
        public IHttpActionResult Approve(int id)
        {
            try
            {
                _adminOperations.Approve(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("admin/reject/{id:int}")]
        public IHttpActionResult Reject(int id)
        {
            try
            {
                _adminOperations.Reject(id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("admin/delete/{id:int}/{indId:int}")]
        public IHttpActionResult Reject(int id, int indId)
        {
            try
            {
                _adminOperations.DeleteIndustry(id, indId);
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}