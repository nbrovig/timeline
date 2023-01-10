using timeline.Data;
using Microsoft.EntityFrameworkCore;

namespace timeline
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TimelineContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, TimelineContext dbContext)
        {
            dbContext.Database.Migrate();
            dbContext.SeedData();
        }

    }
}
