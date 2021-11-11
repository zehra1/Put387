using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Poruka;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorukaController : BaseCRUDController<Poruka, PorukaSearchRequest, PorukaInsertRequest, PorukaInsertRequest>
    {
        public PorukaController(ICRUDRepository<Poruka, PorukaSearchRequest, PorukaInsertRequest, PorukaInsertRequest> service) : base(service)
        {
        }
    }
}