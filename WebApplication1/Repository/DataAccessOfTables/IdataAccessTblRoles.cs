namespace WebApplication1.Repository.DataAccessOfTables
{
    public interface IdataAccessTblRoles<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);
    }
}
