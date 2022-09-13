using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace SmartSim.API
{
    public class Startup
    {



        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigurationService(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Method is a service that can provide static files served as a SPA
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../SmartSim-ui/dist/SmartSim-ui";
            });

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //run the Angular development server by simply running dotnet run
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../SmartSim-ui";
                if (environment.IsDevelopment())
                {
                    //choose which npm script to run
                    //we defined the start script to execute ng serve which will run the Angular development server
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

    }
}
