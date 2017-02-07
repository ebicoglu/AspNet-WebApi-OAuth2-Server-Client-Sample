using System.Web.Http;

namespace WebApi.Controllers
{
    [Authorize(Roles = "boss")]
    public class AdminController : ApiController
    {
        public string Get()
        {
            var isBoss = User.IsInRole("boss");

            return "You are the boss!";
        }
 
    }
}
