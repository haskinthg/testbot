using Microsoft.EntityFrameworkCore;
using WebApplication1.BotService;
using WebApplication1.Commands;

namespace WebApplication1
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();
            services.AddSingleton<Bot>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IExecutor, Executor>();
            services.AddSingleton<BasisCommand, StartCommand>();
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
