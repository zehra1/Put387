using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.MedaljaKorisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class MedaljaKorisnikRepository : CRUDRepository<MedaljaKorisnik, MedaljaKorisnikSearchRequest, Database.Detalji, MedaljaKorisnikUpsertRequest, MedaljaKorisnikUpsertRequest>
    {
        public MedaljaKorisnikRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
