using Put387.Model.Models;
using Put387.Model.Requests.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories.Interfaces
{
    public interface IKorisnik 
    {
        Korisnik Insert(KorisnikUpsertRequest request);
        Korisnik Update(int id, KorisnikUpsertRequest request);
        Korisnik GetById(int id);
        List<Korisnik> Get(KorisnikSearchRequest request);
        void Delete(int id);

        Korisnik Authenticate(KorisnikLoginRequest request);
    }
}
