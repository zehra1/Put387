using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387.Repositories.Interfaces
{
    public interface IRecommendRepository
    {
        List<Model.Models.Voznja> RecommendUsers(int korisnikId);
    }
}
