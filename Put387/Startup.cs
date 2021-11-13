using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Put387.Database;
using Put387.Model.Requests.Detalji;
using Put387.Model.Requests.Kategorija;
using Put387.Model.Requests.Korisnik;
using Put387.Model.Requests.Medalja;
using Put387.Model.Requests.MedaljaKorisnik;
using Put387.Model.Requests.Poruka;
using Put387.Model.Requests.Vozilo;
using Put387.Model.Requests.Voznja;
using Put387.Model.Requests.VoznjaDojam;
using Put387.Model.Requests.VoznjaKorisnici;
using Put387.Model.Requests.Zahtjev;
using Put387.Models.Requests.Kategorija;
using Put387.Repositories;
using Put387.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Put387
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Put387 API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<Put387DbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("Put387ConnectionString")));
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<ICRUDRepository<Model.Models.Detalji, DetaljiSearchRequest, DetaljiUpsertRequest, DetaljiUpsertRequest>, DetaljiRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Medalja, MedaljaSearchRequest, MedaljaInsertRequest, MedaljaInsertRequest>, MedaljaRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.MedaljaKorisnik, MedaljaKorisnikSearchRequest, MedaljaKorisnikUpsertRequest, MedaljaKorisnikUpsertRequest>, MedaljaKorisnikRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Voznja, VoznjaSearchRequest, VoznjaUpsertRequest, VoznjaUpsertRequest>, VoznjaRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.VoznjaDojam, VoznjaDojamSearchRequest, VoznjeDojamInsertRequest, VoznjeDojamInsertRequest>, VoznjaDojamRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.VoziloDetalji, Model.Requests.VoziloDetalji.VoziloDetaljiSearchRequest, Model.Requests.VoziloDetalji.VoziloDetaljiUpsertRequest, Model.Requests.VoziloDetalji.VoziloDetaljiUpsertRequest>, VoziloDetaljiRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.VoznjaKorisnici, VoznjaKorisniciSearchRequest, VoznjaKorisniciUpsertRequest, VoznjaKorisniciUpsertRequest>, VoznjaKorisniciRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>, KategorijaRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Vozilo, VoziloSearchRequest, VoziloUpsertRequest, VoziloUpsertRequest>, VoziloRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Zahtjev, ZahtjevSearchRequest, ZahtjevUpsertRequest, ZahtjevUpsertRequest>, ZahtjevRepository>();
            services.AddScoped<ICRUDRepository<Model.Models.Poruka, PorukaSearchRequest, PorukaInsertRequest, PorukaInsertRequest>, PorukaRepository>();
            services.AddScoped<IKorisnik, KorisnikRepository>();
            services.AddScoped<IRecommendRepository, RecommendRepository>();
            services.AddScoped<IRepository<Model.Models.Grad, Model.Requests.Grad.GradSearchRequest>, GradRepository>();
            services.AddScoped<IRepository<Model.Models.Mjesto, Model.Requests.Mjesto.MjestoSearchRequest>, MjestoRepository>();
            services.AddScoped<IRepository<Model.Models.Uloga, Model.Requests.Uloga.UlogaSearchRequest>, UlogaRepository>();
            services.AddScoped<IRepository<Model.Models.TipVoznje, Model.Requests.TipVoznje.TipVoznjeSearchRrequest>, TipVoznjeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Put387"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
