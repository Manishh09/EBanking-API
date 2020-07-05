using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EBanking.API.BusinessDomain.Concrete;
using EBanking.API.BusinessDomain.Interface;
using EBanking.API.Infrastructure;
using EBanking.API.Models.Context;
using EBanking.API.Service.App_Code;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EBanking
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicyAllowAll",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()                   
                    ));

            #region version
            //services.AddMvcCore().AddJsonOptions().AddVersionedApiExplorer(
            //options =>
            //{
            //    options.GroupNameFormat = "'v'VVV";
            //    options.SubstituteApiVersionInUrl = true;
            //}
            //);
            //services.AddMvc(o =>
            //{
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            ////services.AddApiVersioning(options => options.ReportApiVersions = true);

            #endregion
            #region swagger
            //services.AddSwaggerGen(
            //    options =>
            //    {
            //        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            //        foreach (var description in provider.ApiVersionDescriptions)
            //        {
            //            options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.HttpMethod}_V{description.ApiVersion}_{Guid.NewGuid()}");
            //            options.SwaggerDoc(description.GroupName, new Swashbuckle.AspNetCore.Swagger.Info()
            //            {
            //                Version = "v1",
            //                Title = "Project API",
            //                Description = "EBanking Project API"
            //            });

            //            //var security = new Dictionary<string, IEnumerable<string>>
            //            //{
            //            //    {"Bearer", new string[] { }},
            //            //};
            //            //options.AddSecurityDefinition($"Bearer token for {description.GroupName}", new ApiKeyScheme
            //            //{
            //            //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //            //    Name = "Authorization",
            //            //    In = "header",
            //            //    Type = "apiKey"
            //            //});
            //            //options.AddSecurityRequirement(security);


            //        }
            //        options.OperationFilter<SwaggerDefaultValues>();
            //        options.IncludeXmlComments(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), $"{this.GetType().Assembly.GetName().Name}.xml"));
            //    });
            #endregion

            services.AddControllers();
            services.AddDbContext<EBankingContext>((options) =>
            {
                new SqlConnection(Configuration["Database:ConnectionString"]);
            }, ServiceLifetime.Scoped);

            services.AddTransient<EBankingUnitOfWork>();
            services.AddTransient<ICustomer, CustomerConcrete>();
            services.AddTransient<INotification, NotificationConcrete>();

            services.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;

            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicyAllowAll");

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            ////app.UseSwagger();

            //app.UseSwaggerUI(
            //  options =>
            //  {
            //      foreach (var description in provider.ApiVersionDescriptions)
            //      {
            //          options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            //      }
            //  });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
