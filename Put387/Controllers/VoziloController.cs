using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Vozilo;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloController : BaseCRUDController<Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest>
    {
        public VoziloController(ICRUDRepository<Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest> service) : base(service)
        {
        }
    }
}
