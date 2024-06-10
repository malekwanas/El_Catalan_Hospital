using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.API.Repository.Contract
{
    public interface IGenericRepositoryUser<T> where T : AppUser
    {
        Task<T?> UpdateAsync(string id, T entityToUpdate);

        Task<T?> GetAsync(string id);

        Task SaveChanges();
    }
}
