using DependencySampleLib.GoodSample;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISample.Data;

namespace WebAPISample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //IOContainer 
        {
            //services.AddControllersWithViews // MVC Framework -> Controllerzecihnis + Views-Verzeichnis
            //services.AddRazorPages(); // RazorPages -> Verzenis -> Pages muss vorhanden sein 
            
            


            services.AddControllers().AddXmlSerializerFormatters();  //AddControllers (WebAPI) -> Controllerzechnis muss vorhanden

            services.AddSingleton(typeof(ICar), typeof(MockCar));


            services.AddDbContext<PersonDBContext>(options =>
                    options.UseInMemoryDatabase("PersonDB"));


            //services.AddSingleton(typeof(ICar), typeof(Car)); //Hier wird eine Instanz gebaut -> Wie lange lebt das Objekt bis zur Neuinstanziierung
            //services.AddTransient();
            //services.AddScoped()

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPISample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPISample v1"));
            }
            

            app.UseHttpsRedirection(); //Https wurd unterstüzt

            app.UseRouting(); //Routing-Pattern

            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //MVC Pattern mit WebAPI -> Request reinkommt -> wird dieses an richtiger Controller-Klasse + Methode weitergeleitet.
            });
        }
    }
}
