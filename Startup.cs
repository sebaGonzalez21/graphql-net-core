using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectGraphql.DBContext;
using ProjectGraphql.Repository;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectGraphql.SchemaModel;
using GraphQL.Server.Ui.Playground;
using ProjectGraphql.Util;

namespace ProjectGraphql
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
            // Auto Mapper Configurations
            /**
             * Mapeo de objetos
             * 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingObject());
            });
             IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            */

            services.AddScoped<IDependencyResolver>(x =>
               new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<HotelSchema>();

            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in dev mode.
            })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //...
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Constant.CONEXION_DB)));
            services.AddTransient<ReservationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, HotelDbContext dbContext)
        {
            app.UseGraphQL<HotelSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
