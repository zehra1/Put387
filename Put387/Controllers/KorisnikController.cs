using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Korisnik;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController  : ControllerBase
    {
        IKorisnik _service;
        public KorisnikController(IKorisnik service)
        {
            _service = service;
        }
        
        [AllowAnonymous]
        [HttpPost ("Login")]
        public IActionResult Login([FromBody] KorisnikLoginRequest request)
        {
            var user = _service.Authenticate(request);
            if (user == null)
            {
                return BadRequest(new { message = "Email ili lozinka nisu ispravni!" });
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult AddUser(KorisnikUpsertRequest request)
        {
            var user = _service.Insert(request);
            if (user == null)
            {
                return BadRequest(new { message = "Korisnik vec postoji." });
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<Korisnik> Update(int id, KorisnikUpsertRequest request)
        {
            var user = _service.Update(id,request);
            if (user == null)
            {
                return BadRequest(new { message = "Korisnik ne postoji." });
            }
            return Ok(user);
        }

        [HttpGet]
        public ActionResult<List<Korisnik>> Get([FromQuery]KorisnikSearchRequest request)
        {
            var user = _service.Get(request);
            if (user == null)
            {
                return BadRequest(new { message = "Korisnik ne postoji." });
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public ActionResult<Korisnik> GetById(int id)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return BadRequest(new { message = "Korisnik ne postoji." });
            }
            return Ok(user);
        }
    }
}
