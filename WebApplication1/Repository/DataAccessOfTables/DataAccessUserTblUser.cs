using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository.DataAccessOfTables
{
    public class DataAccessUserTblUser : IDataAccessUserTblUser<TblUser>
    {
        RolebasedContext _db;

        public DataAccessUserTblUser(RolebasedContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TblUser>> GetAll()
        {
            var users = await _db.TblUsers.ToListAsync();
            return users;
        }

        public async Task<TblUser> GetById(int id)
        {
            var user = await _db.TblUsers.Where(a => a.Id == id).FirstOrDefaultAsync();
            return user;
        }
    }
}
