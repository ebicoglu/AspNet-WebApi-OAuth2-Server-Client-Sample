using System.Web.Http;

namespace WebApi.Controllers
{
    public class AuthorizedController : ApiController
    {
        [Authorize]
        public string Get()
        {
            return "You are authorized user!";
        }
    }
}
