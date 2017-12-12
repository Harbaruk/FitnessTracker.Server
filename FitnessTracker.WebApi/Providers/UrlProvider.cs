using FitnessTracker.WebApi.Providers.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessTracker.WebApi.Providers
{
    public class UrlProvider : IUrlProvider
    {
        private readonly HttpRequest _request;

        public UrlProvider(HttpRequest request)
        {
            _request = request;
        }

        public string CurrentUrl
        {
            get
            {
                var appendPort = !(_request.Url.Port == 80 && _request.Url.Scheme == "http" 
                                || _request.Url.Port == 443 && _request.Url.Scheme == "https");
                return string.Format("{0}://{1}{2}{3}",
                                    _request.Url.Scheme,
                                    _request.Url.Host,
                                    appendPort ? (":" + _request.Url.Port) : string.Empty,
                                    _request.ApplicationPath);
            }
        }

        public string ImageUrl
        {
            get
            {
                return CurrentUrl + "/Uploads/Images";
            }
        }
    }
}