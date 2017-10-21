using FitnessTracker.WebApi.Providers.Abstraction;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        public readonly ICurrentUserProvider _currentUserProvider;

        public ApiControllerBase(ICurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;
        }
    }
}
