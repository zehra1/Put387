using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.Voznja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class VoznjaRepository : CRUDRepository<Voznja, VoznjaSearchRequest, Database.Voznja, VoznjaUpsertRequest, VoznjaUpsertRequest>
    {
        public VoznjaRepository(Database.Put387DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Voznja> Get(VoznjaSearchRequest search)
        {
            if (search.searchBy == "nadolazece")
            {
                var querySearch = _context.Voznja.Include(x => x.polaziste).Include(x => x.odrediste).Include(x=>x.tipVoznje).AsQueryable();
                querySearch = querySearch.Where(x => x.DatumVrijemePolaska.Date >= DateTime.Now);
                if (search.tipVoznjeId != 0)
                    querySearch = querySearch.Where(x => x.tipVoznjeId == search.tipVoznjeId);
                
                if (!string.IsNullOrEmpty(search.NazivPolazista))
                    querySearch = querySearch.Where(x => x.odrediste.Naziv.ToLower().Contains(search.NazivPolazista) || x.polaziste.Naziv.ToLower().Contains(search.NazivPolazista));
                
                if (search.BrojSlobodnihMjesta > 0)
                    querySearch = querySearch.Where(x => x.BrojSlobodnihMjesta == search.BrojSlobodnihMjesta);
                
                if (search.Cijena)
                    querySearch = querySearch.Where(x => x.Cijena > 0);
                if (search.desc)
                    querySearch = querySearch.OrderByDescending(x => x.DatumVrijemePolaska);
                return _mapper.Map<List<Voznja>>(querySearch);

            }
            else
            {

            var query = _context.Voznja.Include(x => x.vozac).Include(x => x.polaziste).Include(x => x.odrediste).Include(x=>x.dojmovi).AsQueryable();
            if(search.OdDatuma !=null && search.DoDatuma != null)
            {
                var od = search.OdDatuma.Value.Date;
                var doo = search.DoDatuma.Value.Date;
                query = query.Where(x => x.DatumVrijemePolaska.Date >= od && x.DatumVrijemePolaska.Date <= doo);
            }
            var lista= _mapper.Map<List<Voznja>>(query);
            foreach (var item in lista)
            {
                if (_context.VoznjaDojam.Count(x => x.voznjaId == item.Id) > 0)
                    item.Ocjena = _context.VoznjaDojam.Where(x => x.voznjaId == item.Id).Average(x => x.Ocjena);
                else
                    item.Ocjena = 0;
            }
            return lista.OrderByDescending(x=>x.DatumObjave).ToList();
            }

        }

        public override Voznja GetByID(int id)
        {
            var data = _context.Voznja.Include(x=>x.vozac).Include(x => x.polaziste).Include(x=>x.tipVoznje).Include(x => x.odrediste).Include(x => x.dojmovi).FirstOrDefault(x => x.Id == id);
            var voznja= _mapper.Map<Voznja>(data);
            if (_context.VoznjaDojam.Where(x => x.voznjaId == data.Id).Count() > 0)
                voznja.Ocjena = _context.VoznjaDojam.Where(x => x.voznjaId == data.Id).Average(x => x.Ocjena);
            else voznja.Ocjena = 0;
            return voznja;
        }
        public override Voznja Update(int id, VoznjaUpsertRequest request)
        {
            if (!string.IsNullOrEmpty(request.editBrojMjesta))
            {
                var entity = _context.Voznja.Find(id);
                entity.BrojSlobodnihMjesta = entity.BrojSlobodnihMjesta - request.BrojSlobodnihMjesta;
                _context.Voznja.Update(entity);
                _context.SaveChanges();
                return _mapper.Map<Voznja>(entity);
            }
            return base.Update(id, request);
            
        }
    }
}
