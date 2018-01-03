using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using AzureSecretSanta.Models;
using AzureSecretSanta.Repository;

namespace AzureSecretSanta.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }
    }
}
