using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspSampleChangeLanguage.Controllers
{
    public class CultureController : Controller
    {
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            string cookieName = CookieRequestCultureProvider.DefaultCookieName;
            RequestCulture rc = new RequestCulture(culture);
            string cookieValue = CookieRequestCultureProvider.MakeCookieValue(rc);
            CookieOptions opt = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) };

            Response.Cookies.Append(cookieName, cookieValue, opt);

            return LocalRedirect(returnUrl);
        }
    }
}
