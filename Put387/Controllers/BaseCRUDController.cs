using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<TModel, Tsearch, TInsert, TUpdate> : BaseController<TModel, Tsearch>
    {
        protected readonly ICRUDRepository<TModel, Tsearch, TInsert, TUpdate> _service = null;

        public BaseCRUDController(ICRUDRepository<TModel, Tsearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }

        [HttpPost]
        public TModel Insert(TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }

        [HttpDelete]
        void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
