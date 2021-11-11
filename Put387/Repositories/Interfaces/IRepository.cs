using System.Collections.Generic;

namespace Put387.Repositories.Interfaces
{
    public interface IRepository<TModel, Tsearch>
    {
        List<TModel> Get(Tsearch search);
        TModel GetByID(int id);
    }
}