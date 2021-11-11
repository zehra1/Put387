using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Detalji;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaljiController : BaseCRUDController<Model.Models.Detalji, DetaljiSearchRequest, DetaljiUpsertRequest, DetaljiUpsertRequest>
    {
        public DetaljiController(ICRUDRepository<Detalji, DetaljiSearchRequest, DetaljiUpsertRequest, DetaljiUpsertRequest> service) : base(service)
        {
        }
    }
}
