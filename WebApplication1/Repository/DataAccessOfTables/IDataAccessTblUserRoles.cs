namespace WebApplication1.Repository.DataAccessOfTables
{
    public interface IDataAccessTblUserRoles<TEntity>
    {
        Task<TEntity> GetById(int id);
    }
}
