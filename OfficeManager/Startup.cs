using AutoMapper;
using bs.Data;
using bs.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OfficeManager.Interfaces;
using OfficeManager.Repositories;
using OfficeManager.Services;
using System;
using System.IO;
using System.Reflection;

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

            // Registo Swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Office Manager API",
                    Description = "Backend di Office Manager",
                    Contact = new OpenApiContact
                    {
                        Name = "Fabio Cavallari",
                        Email = "fcavallari@italcom.it",
                        Url = new Uri("https://github.com/babbubba"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT Licence",
                        //Url = new Uri("https://example.com/license"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Office Manager API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
