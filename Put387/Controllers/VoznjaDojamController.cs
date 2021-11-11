using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.VoznjaDojam;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoznjaDojamController : BaseCRUDController<VoznjaDojam, VoznjaDojamSearchRequest, VoznjeDojamInsertRequest, VoznjeDojamInsertRequest>
    {
        public VoznjaDojamController(ICRUDRepository<VoznjaDojam, VoznjaDojamSearchRequest, VoznjeDojamInsertRequest, VoznjeDojamInsertRequest> service) : base(service)
        {
        }
    }
}
