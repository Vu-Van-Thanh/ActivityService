using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayrollService.Core.Services.CommonServiceContract
{
    public interface IService<T, TDto> where T : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(object id);
        Task<IEnumerable<TDto>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<TDto> UpsertAsync(TDto dto, Expression<Func<T, bool>> predicate);
        Task DeleteAsync(object id);  
    }
}
