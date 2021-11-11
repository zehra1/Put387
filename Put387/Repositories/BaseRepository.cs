using AutoMapper;
using Put387.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Put387.Repositories
{
    public class BaseRepository<TModel, Tsearch, TDatabase> : IRepository<TModel, Tsearch> where TDatabase : class
    {
        protected readonly Database.Put387DbContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(Database.Put387DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual List<TModel> Get(Tsearch search)
        {
            return _mapper.Map<List<TModel>>(_context.Set<TDatabase>().ToList());
        }

        public virtual TModel GetByID(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TDatabase>().Find(id));
        }
    }

}