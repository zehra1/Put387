using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.VoznjaKorisnici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class VoznjaKorisniciRepository : CRUDRepository<VoznjaKorisnici, VoznjaKorisniciSearchRequest, Database.VoznjaKorisnici, VoznjaKorisniciUpsertRequest, VoznjaKorisniciUpsertRequest>
    {
        public VoznjaKorisniciRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<VoznjaKorisnici> Get(VoznjaKorisniciSearchRequest search)
        {
            var query = _context.VoznjaKorisnici.Include(x=>x.korisnik).AsQueryable();
            if (search.voznjaId != 0)
                query = query.Where(x => x.voznjaId == search.voznjaId);
            return _mapper.Map<List<VoznjaKorisnici>>(query);
        }
    }
}
