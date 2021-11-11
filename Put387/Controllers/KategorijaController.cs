using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Model.Models;
using Put387.Model.Requests.Kategorija;
using Put387.Models.Requests.Kategorija;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class KategorijaController : BaseController<Kategorija, KategorijaSearchRequest>
    //{
    //    public KategorijaController(IRepository<Kategorija, KategorijaSearchRequest> service) : base(service)
    //    {
    //    }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : BaseCRUDController<Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        private readonly ICRUDRepository<Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest> _service;
        public KategorijaController(ICRUDRepository<Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest> service) : base(service)
        {
            _service = service;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }

}
