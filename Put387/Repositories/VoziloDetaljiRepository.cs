using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.Detalji;
using Put387.Model.Requests.VoziloDetalji;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class VoziloDetaljiRepository : CRUDRepository<VoziloDetalji, VoziloDetaljiSearchRequest, Database.VoziloDetalji, VoziloDetaljiUpsertRequest, VoziloDetaljiUpsertRequest>
    {
        public VoziloDetaljiRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
