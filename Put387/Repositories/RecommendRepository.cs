using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Put387.Database;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories
{
    public class RecommendRepository : IRecommendRepository
    {
        protected readonly Put387DbContext _context;
        protected readonly IMapper _mapper;

        public RecommendRepository(Put387DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Dictionary<int, List<Database.VoznjaDojam>> vehicles = new Dictionary<int, List<Database.VoznjaDojam>>();

        public List<Model.Models.Voznja> RecommendUsers(int vehicleId)
        {
            var tmp = LoadSimilar(vehicleId);
            List<Database.Voznja> voznje = new List<Database.Voznja>();
            foreach (var item in tmp)
            {
                var v = _context.Voznja.Include(x => x.polaziste).Include(x => x.odrediste).Where(x => x.vozacId == item.Id);
                voznje.AddRange(v);
            }
            return _mapper.Map<List<Model.Models.Voznja>>(voznje);
        }

        private List<Database.Korisnik> LoadSimilar(int vehicleId)
        {
            LoadDifVehicles(vehicleId);
            List<Database.VoznjaDojam> ratingsOfThis = _context.VoznjaDojam.Where(e => e.korisnikId != vehicleId).OrderBy(e => e.korisnikId).ToList();

            List<Database.VoznjaDojam> ratings1 = new List<Database.VoznjaDojam>();
            List<Database.VoznjaDojam> ratings2 = new List<Database.VoznjaDojam>();
            List<Database.Korisnik> recommendedVehicles = new List<Database.Korisnik>();

            foreach (var item in vehicles)
            {
                foreach (Database.VoznjaDojam rating in ratingsOfThis)
                {
                    if (item.Value.Where(x => x.voznjaId == rating.voznjaId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(item.Value.Where(x => x.voznjaId == rating.voznjaId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.4)
                {
                    recommendedVehicles.Add(_context.Korisnik.Where(x => x.Id == item.Key)
                        .Include(x => x.grad)
                        .FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedVehicles;
        }

        private double GetSimilarity(List<Database.VoznjaDojam> ratings1, List<Database.VoznjaDojam> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }

            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].Ocjena * ratings2[i].Ocjena;
                y1 += ratings1[i].Ocjena * ratings1[i].Ocjena;
                y2 += ratings2[i].Ocjena * ratings2[i].Ocjena;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadDifVehicles(int vehicleId)
        {
            List<Database.Korisnik> allVehicles = _context.Korisnik.Where(e => e.Id != vehicleId).ToList();
            List<Database.VoznjaDojam> ratings = new List<Database.VoznjaDojam>();
            foreach (var item in allVehicles)
            {
                ratings = _context.VoznjaDojam.Where(e => e.korisnikId == item.Id).OrderBy(e => e.korisnikId).ToList();
                if (ratings.Count > 0)
                    vehicles.Add(item.Id, ratings);
            }
        }
    }
}

