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

        public IEnumerable<Staff> GetAllStaff(int page, string searchText, string sortProperty, string sortDirection)
        {
            var staff = _dbContext.Database.SqlQuery<Staff>
            (
                "exec dbo.[usp_Staff_Filter] @Page,@Searchtext,@SortProperty,@SortDirection",
                    new SqlParameter("@Page", page),
                    new SqlParameter("@SearchText", searchText ?? SqlString.Null),
                    new SqlParameter("@SortProperty", sortProperty ?? SqlString.Null),
                    new SqlParameter("@SortDirection", sortDirection ?? SqlString.Null)
            ).ToList();

            return staff;
        }
    }
}