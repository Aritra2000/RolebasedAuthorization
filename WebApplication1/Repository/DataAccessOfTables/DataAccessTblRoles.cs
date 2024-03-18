using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository.DataAccessOfTables
{
    public class DataAccessTblRoles : IdataAccessTblRoles<TblRole>
    {
        RolebasedContext _db;

        public DataAccessTblRoles(RolebasedContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TblRole>> GetAll()
        {
            return await _db.TblRoles.ToListAsync();
        }

        public async Task<TblRole> GetById(int id)
        {
            return await _db.TblRoles.Where(a=>a.Id==id).FirstOrDefaultAsync();
        }
    }
}
