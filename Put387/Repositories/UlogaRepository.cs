using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class UlogaRepository : BaseRepository<Model.Models.Uloga, Model.Requests.Uloga.UlogaSearchRequest, Database.Uloga>
    {
        public UlogaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
