using AutoMapper;
using Helper;
using Microsoft.EntityFrameworkCore;
using Put387.Model.Models;
using Put387.Model.Requests.Korisnik;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class KorisnikRepository: IKorisnik
    {
        private Database.Put387DbContext _context;
        readonly IMapper _mapper;
        public KorisnikRepository(Database.Put387DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Korisnik Authenticate(KorisnikLoginRequest request)
        {
            var user = _context.Korisnik.FirstOrDefault(x => x.Username == request.Username);
            if (user != null)
            {
                var newHash = HashGenerator.GenerateHash(user.PasswordSalt, request.Password);
                if (user.PasswordHash == newHash)
                {
                    return _mapper.Map<Korisnik>(user);
                }
            }
            return null;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Korisnik Insert(KorisnikUpsertRequest request)
        {
            var user = _context.Korisnik.FirstOrDefault(x => x.Email==request.Email || x.Username==request.Username);
            if (user != null)
                return null;

            var newUser = _mapper.Map<Database.Korisnik>(request);
            newUser.PasswordSalt = HashGenerator.GenerateSalt();
            newUser.PasswordHash = HashGenerator.GenerateHash(newUser.PasswordSalt, request.Password);
            newUser.DatumRegistracije = DateTime.Now;
            _context.Add(newUser);
            _context.SaveChanges();
            return _mapper.Map<Korisnik>(newUser);
        }

        public Korisnik Update(int id, KorisnikUpsertRequest request)
        {
            var entity = _context.Korisnik.Find(id);
            if (request.userEdit)
            {
                entity.gradId = request.gradId;
                entity.Telefon = request.Telefon;
                _context.Korisnik.Update(entity);

            }
            else
            {
                _context.Korisnik.Attach(entity);
                _context.Korisnik.Update(entity);
                _mapper.Map(request, entity);
            }

            _context.SaveChanges();

            return _mapper.Map<Korisnik>(entity);
        }

        public List<Korisnik> Get(KorisnikSearchRequest request)
        {
            var query = _context.Korisnik.Include(x => x.uloga).Include(x=>x.grad).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Ime) || !string.IsNullOrWhiteSpace(request.Prezime))
            {
                query = query.Where(x => x.Ime.Contains(request.Ime) || x.Prezime.Contains(request.Prezime));
            }

            if (request.UlogaId != 0)
            {
                query = query.Where(x => x.ulogaId == request.UlogaId);
            }
            if (request.GradId != 0)
            {
                query = query.Where(x => x.gradId == request.GradId);
            }

            return _mapper.Map<List<Korisnik>>(query.ToList());
        }

        public Korisnik GetById(int id)
        {
            if (id == 0)
                return null;
            var korisnik = _context.Korisnik.Include(x=>x.uloga).Include(x=>x.grad).FirstOrDefault(x=>x.Id==id);
            return _mapper.Map<Korisnik>(korisnik);
        }
    }
}
