using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class MjestoRepository:BaseRepository<Model.Models.Mjesto, Model.Requests.Mjesto.MjestoSearchRequest, Database.Mjesto>
    {
        public MjestoRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
