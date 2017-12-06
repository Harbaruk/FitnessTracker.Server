using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FitnessTracker.WebApi.Providers.Abstraction;
using FitnessTracker.Operations.Abstraction;

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
