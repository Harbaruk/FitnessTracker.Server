﻿using FitnessTracker.DataModel;
using FitnessTracker.Operations.Abstraction;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Web.Http;

namespace FitnessTracker.WebApi.Controllers
{
    [RoutePrefix("auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly IAuthenticationOperations _authOperations;

        public AuthController(ICurrentUserProvider currentUserProvider, IAuthenticationOperations authOper) : base(currentUserProvider)
        {
            _authOperations = authOper;
        }

        [Route("register")]
        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Register(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_authOperations.RegisterUser(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}