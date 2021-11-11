using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Grad;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradController : BaseController<Grad, GradSearchRequest>
    {
        public GradController(IRepository<Grad, GradSearchRequest> service) : base(service)
        {
        }
    }
}
