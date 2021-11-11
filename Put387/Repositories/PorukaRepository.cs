using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.Poruka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class PorukaRepository : CRUDRepository<Poruka, PorukaSearchRequest, Database.Poruka, PorukaInsertRequest, PorukaInsertRequest>
    {
        public PorukaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Poruka> Get(PorukaSearchRequest s)
        {
            if (s.chatovi)
            {
               List<Poruka> respo = new List<Poruka>();

                if (s.vozacId > 0)
                {
                    Poruka respoItem = new Poruka();
                    respoItem.usernames = _context.Poruka.Where(x => x.voznja.vozacId == s.vozacId && x.korisnikId!=s.vozacId).GroupBy(xs => xs.korisnik.Username).Select(z => z.Key);
                    respoItem.voznjes = _context.Poruka.Where(x => x.voznja.vozacId == s.vozacId).GroupBy(xs => xs.voznjaId.ToString()).Select(z => z.Key);
                    respoItem.usernameIds = _context.Poruka.Where(x => x.voznja.vozacId == s.vozacId).GroupBy(xs => xs.korisnikId.ToString()).Select(z => z.Key);
                    respo.Add(respoItem);
                    return respo;
                }
                else if(s.korisnikId>0)
                {
                    Poruka respoItem = new Poruka();
                    respoItem.usernames = _context.Poruka.Where(x => x.korisnikId==s.korisnikId).GroupBy(xs => xs.voznja.vozac.Username).Select(z => z.Key);
                    //respoItem.voznjes = _context.Poruka.Where(x => x.voznja.vozacId == s.vozacId).GroupBy(xs => xs.voznjaId.ToString()).Select(z => z.Key);
                    //respoItem.usernameIds = _context.Poruka.Where(x => x.voznja.vozacId == s.vozacId).GroupBy(xs => xs.korisnikId.ToString()).Select(z => z.Key);
                    respo.Add(respoItem);
                    return respo;
                }

            }
            var query = _context.Poruka.Include(x => x.korisnik).Include(x => x.voznja).Include(x=>x.voznja.vozac).AsQueryable();
            if (!string.IsNullOrEmpty(s.korisnikUsername) && s.vozacId > 0 && s.voznjaId > 0)
            {
                query = query.Where(x => (x.korisnik.Username.StartsWith(s.korisnikUsername) && x.voznja.vozacId == s.vozacId) || (x.korisnikId==s.vozacId && x.voznjaId==s.voznjaId));
            }
            if (s.korisnikId> 0 && !string.IsNullOrEmpty(s.korisnikUsername))
            {
                query = query.Where(x => x.korisnikId==s.korisnikId || x.voznja.vozac.Username.StartsWith(s.korisnikUsername));
            }

            return _mapper.Map<List<Poruka>>(query.ToList());
        }

        public override Poruka GetByID(int id)
        {
            return base.GetByID(id);
        }
    }
}
