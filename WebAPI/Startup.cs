using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            //Autofac,Ninject,CastleWindsor,StructureMAp, LightInject,DryInjecy--->IoC Container
            //AOP için ihtiyacımz var yukardakilerine.
            services.AddControllers();
            //AddSingleton: Tüm bellekte 1 tana eproductmanager oluşturuyor. İstediği kadar client gelsin hespine aynı instance'ı ,ref veriyor.
            // Örneğin sepet tutyorsaki data tutmuyorsak kullanabiliriz.Data tutmamak gerek.

            //Özetle biri ctor da IProductService isterse ona bir product manager newliyoruz.
            services.AddSingleton<IProductService, ProductManager>();
            //Daha sonra IProductDal bağımlılığına da sahip oldugunu gördük.
            services.AddSingleton<IProductDal, EfProductDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
