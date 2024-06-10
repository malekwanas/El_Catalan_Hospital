using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.API.Repository.Contract
{
    public interface IGenericRepositoryUser<T> where T : AppUser
    {
        Task<T?> UpdateAsync(int id, T entityToUpdate);

        Task<T?> GetAsync(int id);

        Task SaveChanges();
    }
}
