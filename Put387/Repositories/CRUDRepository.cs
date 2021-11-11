using AutoMapper;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class CRUDRepository<TModel, Tsearch, TDatabase, TInsert, TUpdate> : BaseRepository<TModel, Tsearch, TDatabase>, ICRUDRepository<TModel, Tsearch, TInsert, TUpdate> where TDatabase : class
    {
        public CRUDRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            if (entity == null)
                throw new ArgumentNullException();
            else
            {
                _context.Set<TDatabase>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
