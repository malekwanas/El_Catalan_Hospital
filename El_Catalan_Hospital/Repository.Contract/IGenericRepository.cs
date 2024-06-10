namespace El_Catalan_Hospital.API.Repository.Contract
{
    public interface IGenericRepository<T>
    {
       

        Task<T?> AddAsync(T entity);


    }
}
