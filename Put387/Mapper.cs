using AutoMapper;
using Put387.Model.Requests.Korisnik;
using Put387.Model.Requests.Medalja;
using Put387.Model.Requests.Poruka;
using Put387.Model.Requests.Vozilo;
using Put387.Model.Requests.Voznja;
using Put387.Model.Requests.VoznjaDojam;
using Put387.Model.Requests.VoznjaKorisnici;
using Put387.Model.Requests.Zahtjev;
using Put387.Models.Requests.Kategorija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Models.Korisnik>().ReverseMap();
            CreateMap<Database.Korisnik, KorisnikUpsertRequest>().ReverseMap();
            CreateMap<Database.Korisnik, KorisnikUpsertRequest>().ReverseMap();

            CreateMap<Database.Uloga, Model.Models.Uloga>().ReverseMap();

            CreateMap<Database.Grad, Model.Models.Grad>().ReverseMap();

            CreateMap<Database.Mjesto, Model.Models.Mjesto>().ReverseMap();

            CreateMap<Database.TipVoznje, Model.Models.TipVoznje>().ReverseMap();

            CreateMap<Database.Voznja, Model.Models.Voznja>().ReverseMap();
            CreateMap<Database.Voznja, VoznjaUpsertRequest>().ReverseMap().ForMember(dest => dest.DatumVrijemePolaska, opt => opt.MapFrom(src => DateTime.Parse(src.DatumVrijemePolaska)));

            CreateMap<Database.VoznjaDojam, Model.Models.VoznjaDojam>().ReverseMap();
            CreateMap<Database.VoznjaDojam, VoznjeDojamInsertRequest>().ReverseMap();

            CreateMap<Database.Medalja, Model.Models.Medalja>().ReverseMap();
            CreateMap<Database.Medalja, MedaljaInsertRequest>().ReverseMap();

            CreateMap<Database.Kategorija, Model.Models.Kategorija>().ReverseMap();
            CreateMap<Database.Kategorija, KategorijaUpsertRequest>().ReverseMap();


            CreateMap<Database.VoznjaKorisnici, Model.Models.VoznjaKorisnici>().ReverseMap();
            CreateMap<Database.VoznjaKorisnici, VoznjaKorisniciUpsertRequest>().ReverseMap();

            CreateMap<Database.Vozilo, Model.Models.Vozilo>().ReverseMap();
            CreateMap<Database.Vozilo, VoziloUpsertRequest>().ReverseMap();

            CreateMap<Database.Zahtjev, Model.Models.Zahtjev>().ReverseMap();
            CreateMap<Database.Zahtjev, ZahtjevUpsertRequest>().ReverseMap();


            CreateMap<Database.Poruka, Model.Models.Poruka>().ReverseMap();
            CreateMap<Database.Poruka, PorukaInsertRequest>().ReverseMap();
        }
    }
}
