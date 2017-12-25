using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Providers.Abstraction;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("news")]
    public class NewsController : ApiControllerBase
    {
        private readonly INewsOperations _newsOperations;

        public NewsController(ICurrentUserProvider currentUserProvider, INewsOperations newsOperations) : base(currentUserProvider)
        {
            _newsOperations = newsOperations;
        }

        [Route("get_all")]
        [HttpGet]
        public IHttpActionResult GetNews()
        {
            return Ok(_newsOperations.GetNews());
        }
    }
}