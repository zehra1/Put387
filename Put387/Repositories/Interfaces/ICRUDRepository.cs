using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories.Interfaces
{
    public interface ICRUDRepository<TModel, Tsearch, TInsert, TUpdate> : IRepository<TModel, Tsearch>
    {
        TModel Insert(TInsert request);
        TModel Update(int id, TUpdate request);
        void Delete(int id);
    }
}
