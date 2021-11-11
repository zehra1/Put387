using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.Detalji;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class DetaljiRepository : CRUDRepository<Detalji,DetaljiSearchRequest,Database.Detalji,DetaljiUpsertRequest,DetaljiUpsertRequest>
    {
        public DetaljiRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
