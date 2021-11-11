using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Zahtjev;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahtjevController : BaseCRUDController<Zahtjev, ZahtjevSearchRequest, ZahtjevUpsertRequest, ZahtjevUpsertRequest>
    {
        public ZahtjevController(ICRUDRepository<Zahtjev, ZahtjevSearchRequest, ZahtjevUpsertRequest, ZahtjevUpsertRequest> service) : base(service)
        {
        }
    }
}
