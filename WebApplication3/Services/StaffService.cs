using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class StaffService
    {
        private readonly ApplicationDbContext _dbContext;

        public StaffService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Staff> GetAllStaff(int page, string searchText)
        {
            var staff = _dbContext.Database.SqlQuery<Staff>
            (
                "exec dbo.[usp_Staff_Filter] @Page,@Searchtext",
                    new SqlParameter("@Page", page),
                    new SqlParameter("@SearchText", searchText ?? SqlString.Null)
            ).ToList();

            return staff;
        }
    }
}