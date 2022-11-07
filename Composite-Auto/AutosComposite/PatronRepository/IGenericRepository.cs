using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Auto.GenericRepository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable> GetAllAsync();
        Task DeleteRowAsync(Guid id);
        Task GetAsync(Guid id);
        Task SaveRangeAsync(IEnumerable list);
        Task UpdateAsync(T t);
        Task InsertAsync(T t);
    }
}
