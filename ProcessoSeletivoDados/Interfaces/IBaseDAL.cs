using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessoSeletivoDataContext.Interfaces
{
    public interface IBaseDAL<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(int Id);

        IQueryable<T> Query();

        T GetById(int Id);

        IEnumerable<T> ListAll();
    }
}
