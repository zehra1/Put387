using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.Vozilo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class VoziloRepository : CRUDRepository<Vozilo, VoziloSearchRequest, Database.Vozilo, VoziloUpsertRequest, VoziloUpsertRequest>
    {
        public VoziloRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Vozilo> Get(VoziloSearchRequest search)
        {
            var query = _context.Vozilo.AsQueryable();
            if (search.vozacId!=0)
            {
                query = query.Where(x => x.KorisnikId == search.vozacId);
            }
            return _mapper.Map<List<Vozilo>>(query.ToList());
        }

        public override Vozilo GetByID(int id)
        {
            var vozilo = _context.Vozilo.FirstOrDefault(x => x.KorisnikId == id);
            return _mapper.Map<Vozilo>(vozilo);
        }

    }
}
