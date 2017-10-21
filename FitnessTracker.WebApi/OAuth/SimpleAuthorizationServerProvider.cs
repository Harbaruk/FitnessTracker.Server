using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitnessTracker.WebApi.OAuth
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationOperations _authOperations;

        public SimpleAuthorizationServerProvider(
            Func<IAuthenticationOperations> authOperationsFactory)
        {
            _authOperations = authOperationsFactory.Invoke();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            UserModel user = _authOperations.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("Invalid user");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserType.ToString()));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                         { "id", user.Id.ToString() }
                     });

            //_expirationTokenOperations.Update(new ExpirationTokenModel
            //{
            //    UserId = user.BaseId
            //});

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
