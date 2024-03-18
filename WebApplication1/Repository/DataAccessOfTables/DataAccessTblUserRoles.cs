using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository.DataAccessOfTables
{
    
    public class DataAccessTblUserRoles : IDataAccessTblUserRoles<TblUserRole>
    {
        RolebasedContext _db;

        public DataAccessTblUserRoles(RolebasedContext db)
        {
            _db = db;
        }
        public async Task<TblUserRole> GetById(int id)
        {
            return await _db.TblUserRoles.Where(a => a.UserId == id).FirstOrDefaultAsync();
        }
    }
}
