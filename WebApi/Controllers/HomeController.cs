using System.Web.Http;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        public dynamic Get()
        {
            return new {Wellcome = "Sestek ASP.NET WebApi Sample"};
        }
    }
}
