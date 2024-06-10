using El_Catalan_Hospital.API.Repository.Contract;
using El_Catalan_Hospital.DataAccessLayer;
using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.API.Repository
{

  public class GenericRepositoryUser<T> : IGenericRepositoryUser<T> where T : AppUser
    {

        private readonly DatabaseContext _dbcontext;
        public GenericRepositoryUser(DatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T?> GetAsync(int id)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<T?> UpdateAsync(int id, T entityToUpdate)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbcontext.Entry(entity).CurrentValues.SetValues(entityToUpdate);

            }
            return entity;
        }


    }
}
