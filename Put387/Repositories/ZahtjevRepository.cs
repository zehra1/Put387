using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.Zahtjev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class ZahtjevRepository : CRUDRepository<Zahtjev, ZahtjevSearchRequest, Database.Zahtjev, ZahtjevUpsertRequest, ZahtjevUpsertRequest>
    {
        public ZahtjevRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override Zahtjev Insert(ZahtjevUpsertRequest request)
        {
            if(_context.Zahtjev.Where(x=>x.korisnikId==request.korisnikId && x.voznjaId == request.voznjaId).Count() > 0)
                return null;
            var cijenaVoznje = _context.Voznja.Find(request.voznjaId).Cijena;
            if (cijenaVoznje > 0)
                request.isPaid = true;
            return base.Insert(request);
        }

        public override List<Zahtjev> Get(ZahtjevSearchRequest s)
        {
            var list = _context.Zahtjev.Include(x=>x.voznja).Include(x => x.voznja.polaziste).Include(x => x.voznja.odrediste).AsQueryable();
            if (s.KorisnikId != 0)
                list = list.Where(x => x.korisnikId == s.KorisnikId);
            if (s.VozacId != 0)
                list = list.Where(x => x.voznja.vozacId == s.VozacId);
            return _mapper.Map<List<Zahtjev>>(list.ToList());
        }
    }
}
