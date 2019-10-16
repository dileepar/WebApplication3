using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication3.CypadWebReference;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [EnableCors("http://localhost:4200","*","*")]
    public class StaffController : ApiController
    {
        public  IHttpActionResult Get(int page, string searchText)
        {
            var service = new StaffService();

            var staff =  service.GetAllStaff(page, searchText);

            return Ok(staff);
        }

        public IHttpActionResult GetUrls()
        {
            var service = new CypadSQMSync();
            var url = service.GetMealSelectionURL("B298D3AE-358F-E811-80E2-00059A3C7A00");
            return Ok(url);
        }
    }
}
