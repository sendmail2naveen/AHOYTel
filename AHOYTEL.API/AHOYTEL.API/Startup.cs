using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Antiforgery;
using AHOYTel.LIB.Application;
using AHOYTEL.API.Logic;
using AHOYTel.Repository.DB;

namespace AHOYTEL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IConfigurationRoot root)
        {
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(provider => root);
            DynamoDbInjectionHelper.ConfigureServices(services);
            services.AddTransient<IApiWorkflowManager, ApiWorkflowManager>();
            services.AddTransient<IBookingProcessor, BookingProcessor>();
            services.AddTransient<ISearchProcessor, SearchProcessor>();
            services.AddMvcCore().AddNewtonsoftJson(opts => opts.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);



            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme).AddAzureADBearer(options => Configuration.Bind("AzureActiveDirectory", options));

            // Register Swagger  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Sample API", Version = "version 1" });
            });

            //Add Cross Origin Policy
            string allowedOrigins = Configuration.GetValue<string>("System:AllowedOrigins");
            services.AddCors(options =>
            {
                options.AddPolicy("Client", builder => builder
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .AllowCredentials()
                                            .WithOrigins(allowedOrigins.Split(","))
                                );
            });
            /*services.AddMvcCore(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.  
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
                // specifying the Swagger JSON endpoint.  
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AHOYTEL API V1");
                });
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("Client");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
