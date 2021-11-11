using AutoMapper;
using Put387.Model.Models;
using Put387.Model.Requests.Kategorija;
using Put387.Models.Requests.Kategorija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    //public class KategorijaRepository : BaseRepository<Model.Models.Kategorija, Model.Requests.Kategorija.KategorijaSearchRequest, Database.Kategorija>
    //{
    //    public KategorijaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
    //    {
    //    }
    //}

    public class KategorijaRepository : CRUDRepository<Kategorija, KategorijaSearchRequest, Database.Kategorija, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        public KategorijaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
