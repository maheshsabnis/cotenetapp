using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.Services
{
    /// <summary> 
    /// The Multi-Type Generic Interface that will accept
    /// TEntity as Entity Classand TPk will always be
    /// an input parameter
    /// This iterface will contain Async Methods for
    /// CRUD Operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IServiceRepository<TEntity, in TPk> 
            where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);


    }
}
