namespace WebApplication1.Repository.DataAccessOfTables
{
    public interface IDataAccessUserTblUser<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);


    }
}
