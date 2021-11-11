using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.MedaljaKorisnik;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedaljaKorisnikController : BaseCRUDController<MedaljaKorisnik, MedaljaKorisnikSearchRequest, MedaljaKorisnikUpsertRequest, MedaljaKorisnikUpsertRequest>
    {
        public MedaljaKorisnikController(ICRUDRepository<MedaljaKorisnik, MedaljaKorisnikSearchRequest, MedaljaKorisnikUpsertRequest, MedaljaKorisnikUpsertRequest> service) : base(service)
        {
        }
    }
}
