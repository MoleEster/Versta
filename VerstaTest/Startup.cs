using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Npgsql;
using VerstaTest.Core.Abstract;
using VerstaTest.Core.Services;
using VerstaTest.Data;
using VerstaTest.Data.Data;
using VerstaTest.Options.Extensions;
using VerstaTest.Options.Options;
using VerstaTest.Postgres;
using VerstaTest.Postgres.Abstract;

namespace VerstaTest
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
            services.AddRazorPages();
            services.AddMvc();
            services.AddControllers();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPostgresWorker<Order>, PostgresWorker<Order>>();
            services.RegisterOptions(Configuration);
            services.AddDbContext<DataContext>();
            services.AddSingleton(provider =>
            {
                var postgresOptions = provider.GetRequiredService<IOptions<PostgresOptions>>().Value;
                var conntectionBuilder = new NpgsqlConnectionStringBuilder
                {
                    Host = postgresOptions.Host,
                    Port = postgresOptions.Port,
                    Username = postgresOptions.Username,
                    Password = postgresOptions.Password,
                    Database = postgresOptions.Database
                };

                DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DataContext>()
                    .UseNpgsql(conntectionBuilder.ToString());

                return builder.Options;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
