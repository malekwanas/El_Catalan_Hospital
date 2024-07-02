using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public interface IGenericRepository<T>  where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(int pageIndex, int pageSize);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);

      
    }

}
