using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Medalja;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedaljaController : BaseCRUDController<Medalja, MedaljaSearchRequest, MedaljaInsertRequest, MedaljaInsertRequest>
    {
        public MedaljaController(ICRUDRepository<Medalja, MedaljaSearchRequest, MedaljaInsertRequest, MedaljaInsertRequest> service) : base(service)
        {
        }
    }
}