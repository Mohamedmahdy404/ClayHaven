using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Generic
{
   public interface IGenericRepo<T> where T:class
   {
       Task<List<T>> GetAllData();
       Task<T> GetById(Guid id);
       Task Add(T entity);
       Task Update(T entity);
       Task Remove(Guid id);

   }
}
