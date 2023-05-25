using HelloProject.Repositories;
using HelloProject.Services;
using System.Data;
using System.Data.SqlClient;

namespace HelloProject
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
            // Read connection string from appsettings.json
            var connectionString = Configuration.GetConnectionString("DefaultConnectionString");

            services.AddControllersWithViews();

            services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));
            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddTransient<IContactsService, ContactsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}