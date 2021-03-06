using Betb2bTestApp.Infrastructure;
using Betb2bTestApp.Services;
using Betb2bTestAppModels.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Betb2bTestApp
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
            services.AddMvc(options => options.OutputFormatters.Add(new HtmlOutputFormatter()));
            services.AddMvc(options => options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
            services.AddControllers().AddXmlSerializerFormatters().AddNewtonsoftJson();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ISimpleCache<int, UserInfoModel>, SimpleCache<int, UserInfoModel>>();
            services.AddHostedService<CacheFillerService>();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public class HtmlOutputFormatter : StringOutputFormatter
        {
            public HtmlOutputFormatter()
            {
                SupportedMediaTypes.Add("text/html");
            }
        }
    }
}
