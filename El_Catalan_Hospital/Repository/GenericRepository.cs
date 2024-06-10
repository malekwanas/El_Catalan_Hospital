using El_Catalan_Hospital.API.Repository.Contract;
using El_Catalan_Hospital.DataAccessLayer;

namespace El_Catalan_Hospital.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly DatabaseContext _dbcontext;
        public GenericRepository(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T?> AddAsync(T entity)
        {

            await _dbcontext.AddAsync(entity);
            return entity;
        }

    }
}