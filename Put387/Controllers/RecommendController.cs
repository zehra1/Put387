using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendRepository _service;

        public RecommendController(IRecommendRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Models.Voznja> RecommendUsers([FromQuery] int korisnikId)
        {
            return _service.RecommendUsers(korisnikId);
        }
    }
}
