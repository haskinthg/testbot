using Microsoft.EntityFrameworkCore;
using WebApplication1.BotService;
using WebApplication1.Commands;

namespace WebApplication1
{
    public class Startup
    {

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
            services.AddSingleton<Bot>();
            services.AddSingleton<BasisCommand, StartCommand>();
            services.AddSingleton<UserService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var db = new DataContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }

            serviceProvider.GetRequiredService<Bot>().GetBot().Wait();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();

             });
        }
    }
}
