using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.VoznjaDojam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class VoznjaDojamRepository : CRUDRepository<VoznjaDojam, VoznjaDojamSearchRequest, Database.VoznjaDojam, VoznjeDojamInsertRequest, VoznjeDojamInsertRequest>
    {
        public VoznjaDojamRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override VoznjaDojam Insert(VoznjeDojamInsertRequest request)
        {
            var entity = _context.Zahtjev.Find(request.zahtjevId);
            if (entity != null)
            {
                entity.isReviewed = true;
                _context.Zahtjev.Update(entity);
                _context.SaveChanges();
            }
            return base.Insert(request);
        }

        public override List<VoznjaDojam> Get(VoznjaDojamSearchRequest search)
        {
            var query = _context.VoznjaDojam.Include(x => x.voznja).Include(x => x.voznja.vozac).Include(x=>x.korisnik).AsQueryable();
            if (search.voznjaId!=0)
                query = query.Where(x => x.voznjaId == search.voznjaId);
            if (search.vozacId != 0)
            {
                if (_context.Korisnik.Find(search.vozacId).ulogaId == 2)
                {
                query = query.Where(x => x.voznja.vozacId == search.vozacId);

                }
                else
                    query = query.Where(x => x.korisnikId == search.vozacId);

            }
            return _mapper.Map<List<VoznjaDojam>>(query);
        }
    }
}
