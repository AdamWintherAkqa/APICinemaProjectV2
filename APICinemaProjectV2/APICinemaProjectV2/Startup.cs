using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using APICinemaProject2.DAL.Database;

using Microsoft.OpenApi.Models;
using APICinemaProjectV2.DAL.Repositories;
using APICinemaProject2.DAL.Repositories;

namespace APICinemaProject2
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
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<ICandyShopRepository, CandyShopRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IMerchandiseRepository, MerchandiseRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ILoyaltyProgramRepository, LoyaltyProgramRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<IMovieTimeRepository, MovieTimeRepository>();
            services.AddDbContext<AbContext>();
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APICinemaProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APICinemaProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
