using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.VoznjaKorisnici;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoznjaKorisniciController : BaseCRUDController<VoznjaKorisnici, VoznjaKorisniciSearchRequest, VoznjaKorisniciUpsertRequest, VoznjaKorisniciUpsertRequest>
    {
        public VoznjaKorisniciController(ICRUDRepository<VoznjaKorisnici, VoznjaKorisniciSearchRequest, VoznjaKorisniciUpsertRequest, VoznjaKorisniciUpsertRequest> service) : base(service)
        {
        }
    }
}
