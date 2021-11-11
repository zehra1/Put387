using Microsoft.AspNetCore.Mvc;
using Put387.Model.Requests.Uloga;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlogaController : BaseController<Model.Models.Uloga, UlogaSearchRequest>
    {
        public UlogaController(IRepository<Model.Models.Uloga, UlogaSearchRequest> service) : base(service)
        {
        }
    }
}
