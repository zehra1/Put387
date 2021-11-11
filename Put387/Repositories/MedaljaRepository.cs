using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.Medalja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class MedaljaRepository : CRUDRepository<Medalja, MedaljaSearchRequest, Database.Medalja, MedaljaInsertRequest, MedaljaInsertRequest>
    {
        public MedaljaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Medalja> Get(MedaljaSearchRequest search)
        {
            var query = _context.Medalja.AsQueryable();
            if (search.kategorijaId != 0)
            {
                query = query.Where(x => x.kategorijaId == search.kategorijaId);
            }
            return _mapper.Map<List<Medalja>>(query.ToList());
        }
    }
}
