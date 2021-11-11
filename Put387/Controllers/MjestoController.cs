using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Mjesto;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MjestoController : BaseController<Mjesto, MjestoSearchRequest>
    {
        public MjestoController(IRepository<Mjesto, MjestoSearchRequest> service) : base(service)
        {
        }
    }
}
