using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.VoziloDetalji;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoziloDetaljiController : BaseCRUDController<VoziloDetalji, VoziloDetaljiSearchRequest, VoziloDetaljiUpsertRequest, VoziloDetaljiUpsertRequest>
    {
        public VoziloDetaljiController(ICRUDRepository<VoziloDetalji, VoziloDetaljiSearchRequest, VoziloDetaljiUpsertRequest, VoziloDetaljiUpsertRequest> service) : base(service)
        {
        }
    }
}
