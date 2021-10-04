using System;
using System.Collections.Generic;

namespace DAL
{
    //  This is generic interface using to implement DAL functionalities.
   public interface IDAL<TEntity>
    {
        bool Save(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        TEntity GetById(object obj);
        List<TEntity> GetAll();
    }
}
