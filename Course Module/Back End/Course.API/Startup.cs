using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.DbContexts;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Domain.Mappers;

namespace Course.API
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
            services.AddControllers();

            string connection = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<CourseDbContext>(options => options.UseMySql(connection, 
                    options => options.MigrationsAssembly("Core")));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<CourseDbContext>();

                            // var mappingConfig = new MapperConfiguration(mc =>
                            // {
                            //     mc.AddProfile(new MappingProfile());
                            // });
                            // IMapper mapper = mappingConfig.CreateMapper();
                            // services.AddSingleton(mapper);

            services.AddAutoMapper(typeof(MappingProfile));

            // // services.AddTransient<ILecturerRepository, LecturerRepository>();
            // // services.AddTransient<ILecturerService, LecturerService>();

            services.Register();
            
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
