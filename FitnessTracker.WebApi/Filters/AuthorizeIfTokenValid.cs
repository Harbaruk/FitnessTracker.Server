using FitnessTracker.DataModel;
using FitnessTracker.DataModel.Enums;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FitnessTracker.WebApi.Filters
{
    public class AuthorizeIfTokenValid : AuthorizeAttribute
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
            if (!currentUserProvider.IsAuthenticated || (currentUserProvider.CurrentUserRole == UserType.NotDefined))
            {
                return false;
            }

            var expirationTokenOperations = (IExpirationTokenOperations)actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IExpirationTokenOperations));

            var isExpired = expirationTokenOperations.CheckExpiration(currentUserProvider.CurrentUserId);
            if (!isExpired)
            {
                expirationTokenOperations.Update(new ExpirationTokenModel
                {
                    UserId = currentUserProvider.CurrentUserId,
                    LastActivityDateTime = DateTimeOffset.Now
                });
                return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            throw new HttpResponseException(message);
        }
    }
}
