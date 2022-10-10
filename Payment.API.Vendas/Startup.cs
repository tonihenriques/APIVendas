using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Payment.API.Vendas.Config;
using Payment.API.Vendas.Repository;
using Payment.API.Vendas.Service.IService;
using Payment.API.Vendas.Service.ServiceConcrete;
using System;

namespace Payment.API.Vendas
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
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IOrderVendastRepository, OrderVendasRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddControllers();

            //services.AddHttpClient<IOrderVendastRepository, OrderVendasRepository>(c =>
            //       c.BaseAddress = new Uri(Configuration["ServiceUrls:ProductAPI"])
            //   );

            services.AddHttpClient<IProductService, ProductService>(c =>
                  c.BaseAddress = new Uri(Configuration["ServiceUrls:ProductAPI"])
              );

            services.AddHttpClient<IEmpregadoService, EmpregadoService>(c =>
                  c.BaseAddress = new Uri(Configuration["ServiceUrls:EmpregadoAPI"])
              );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment.API.Vendas", Version = "v1",
                    Description = "API de Gerencimento de Vendas",
                    Contact = new OpenApiContact
                    {
                        Name = "Antonio Henriques",
                        Email = "antonio.hpereira@icloud.com",

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Open License"
                    }
                
                
                });

                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment.API.Vendas v1"));
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
