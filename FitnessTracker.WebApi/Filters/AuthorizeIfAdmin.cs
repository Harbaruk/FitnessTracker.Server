using FitnessTracker.DataModel.Enums;
using FitnessTracker.WebApi.Providers.Abstraction;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FitnessTracker.WebApi.Filters
{
    public class AuthorizeIfAdmin : AuthorizeAttribute
    {
        public bool AllowVirtual = false;

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Response == null)
            {
                if (CheckTokenValidation(actionContext))
                {
                    return;
                }
                HandleUnauthorizedRequest(actionContext);
            }
        }

        public bool CheckTokenValidation(HttpActionContext actionContext)
        {
            var currentUserProvider = (ICurrentUserProvider)actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ICurrentUserProvider));
            if (currentUserProvider.CurrentUserRole != UserType.Admin)
            {
                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            throw new HttpResponseException(message);
        }
    }
}