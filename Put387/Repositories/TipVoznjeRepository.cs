using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class TipVoznjeRepository : BaseRepository<Model.Models.TipVoznje, Model.Requests.TipVoznje.TipVoznjeSearchRrequest, Database.TipVoznje>
    {
        public TipVoznjeRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
