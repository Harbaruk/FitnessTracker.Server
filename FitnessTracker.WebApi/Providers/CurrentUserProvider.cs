using FitnessTracker.DataModel.Enums;
using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Security.Claims;
using System.Web;

namespace FitnessTracker.WebApi.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public int CurrentUserId
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return -1;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var claim = user.FindFirst(ClaimTypes.NameIdentifier);
                return claim == null ? -1 : int.Parse(claim.Value);
            }
        }

        public string CurrentUserEmail
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return string.Empty;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var email = user.FindFirst(ClaimTypes.Email).Value;
                return email;
            }
        }

        public UserType CurrentUserRole
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return UserType.NotDefined;
                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var role = user.FindFirst(ClaimTypes.Role);
                return role == null ? UserType.NotDefined : (UserType)Enum.Parse(typeof(UserType), role.Value, true);
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        public bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.User == null)
                    return false;

                var user = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var role = (UserType)Enum.Parse(typeof(UserType), user.FindFirst(ClaimTypes.Actor).Value, true);
                if (role == UserType.Admin)
                    return true;
                else return false;
            }
        }
    }
}
