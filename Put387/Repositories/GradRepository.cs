using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class GradRepository : BaseRepository<Model.Models.Grad, Model.Requests.Grad.GradSearchRequest, Database.Grad>
    {
        public GradRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
