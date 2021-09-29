using bs.Data;
using bs.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficeManager.Interfaces;
using OfficeManager.Repositories;
using OfficeManager.Services;
using System;

namespace OfficeManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Questo metodo è chiamato all'avvio dell'applicazione ed esegue la registrazione di tutti i servizi nel
        // Container utilizzato per la Dependency Injection (DI).
        // PS: La DI è uno di quei pattern che cambia la vita ad un programmatore!
        public void ConfigureServices(IServiceCollection services)
        {
            // Preparo le informazioni necessarie all' O.R.M. (nhibernate) per utilizzare un database SqlLite
            // Usiamo un pacchetto che fa già il grosso del lavoro al posto nostro che si chiama bs.Data
            // NB: usare un ORM ci permette di sfruttare al meglio la programamzione ad oggetti senza scrivere una riga di SQL.
            // L'ORM utilizzato si chiama nHibernate ed è sicuramente una delle cose più lunghe da apprendere... 
            IDbContext dbContext = new DbContext
            {
                ConnectionString = "Data Source=.\\OfficeManager.db;Version=3;BinaryGuid=False;",
                DatabaseEngineType = DbType.SQLite,
                Create = true,
                Update = true,
            };


            // Chiamo un metodo del paccheto bs.Data che registra nei servizi dell'applicazione l' ORM,
            // lo configura, legge e crea il mapping dei 'Models', registra la Unit Of Work (gestione transazioni)
            // e registra il Repository base (che sarà la classe base di ogni repository che creeremo noi)
            services.AddBsData(dbContext);

            // Registro tutti i profili di mapping di Automapper. Automapper è una libreria che ci permette di fare in modo rapido la
            // trasformazione di una classe model in una classe view model e viceversa
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Registro i repositories che abbiamo creato.
            // NB: Il pattern repository alle volte rende più laborioso lo sviluppo ma rende l'applicazione molto piu scalabile 
            // e leggibile
            services.AddScoped<IPersonsRepository, PersonsRepository>();
            services.AddScoped<IPersonsService, PersonsService>();

            // Questo fa in modo che i controllers vengano registrati come servizi e di conseguenza possano
            // accedere agli altri servizi registrati tramite DI (Dependency Injection)
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
