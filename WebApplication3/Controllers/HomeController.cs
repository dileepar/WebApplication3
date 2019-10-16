using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.CypadWebReference;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var service = new CypadSQMSync();
            var url = service.GetMealSelectionURL("B298D3AE-358F-E811-80E2-00059A3C7A00");
            return Content(url);
        }
    }
}