using EmployeeVerificationAPI.IModelRepository;
using EmployeeVerificationAPI.ModelRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeeVerification
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
                  services.AddCors();
                  services.AddControllers();
                  services.AddSwaggerGen();
                  services.AddSwaggerGen(c =>
                  {
                        c.SwaggerDoc("v1" , new OpenApiInfo
                        {
                              Version = "v1" ,
                              Title = "Implement Swagger UI" ,
                              Description = "A simple example to Implement Swagger UI" ,
                        });
                  });
                  services.AddScoped<IEmployeeRepository , EmployeeRepository>();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
            {
                  if(env.IsDevelopment())
                  {
                        //app.UseDeveloperExceptionPage();
                        app.UseSwagger();
                        app.UseSwaggerUI(c => {
                              c.SwaggerEndpoint("/swagger/v1/swagger.json" , "Showing API V1");
                        });
                  }

                  app.UseCors(x =>
                                         x.AllowAnyOrigin()
                                           .AllowAnyMethod()
                                           .AllowAnyHeader()
                                           .WithExposedHeaders("*"));

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
