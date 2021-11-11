using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Voznja;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class VoznjaController :BaseCRUDController<Voznja, VoznjaSearchRequest, VoznjaUpsertRequest, VoznjaUpsertRequest>
    {
        public VoznjaController(ICRUDRepository<Voznja, VoznjaSearchRequest, VoznjaUpsertRequest, VoznjaUpsertRequest> service) : base(service)
        {
        }
    }
}
