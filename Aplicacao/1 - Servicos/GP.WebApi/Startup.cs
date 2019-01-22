using System;
using AutoMapper;
using GP.Aplicacao.AutoMapper;
using GP.Aplicacao.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace GP.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddCors();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("V1", new Info
                {
                    Title = "Gerenciamento de Patrimônios",
                    Version = "v1",
                    Description = "Projeto em .NET Core 2 utilizando DDD.",
                    TermsOfService = "...",
                    Contact = new Contact { Name = "Lennon V. Alves Dias", Email = "lennonalvesdias@gmail.com", Url = "http://www.lennonalves.com.br" },
                    License = new License { Name = "", Url = "" }
                });

                s.DescribeAllEnumsAsStrings();
                s.SchemaFilter<SwaggerExcludeFilter>();
            });

            RecursosCompartilhados.DIConfiguration.ConfigurationService.Builder(Configuration, services);

            services.AddMvc(s => s.Filters.Add(new ValidateModelAttribute()))
            .AddJsonOptions(s =>
            {
                s.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                s.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                s.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            AutoMapperConfig.RegisterMappings();

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Swagger/V1/swagger.json", "Gerenciamento de Patrimônios v1");
                c.DocumentTitle = "Documentation";
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            Infra.NativeInjectorBootStrapper.RegisterServices(services);
            RecursosCompartilhados.Infra.NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
