using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Sp4service.context;
using Sp4service.service;

namespace Sp4service
{
    public class Startup
    {
        //private MySqlContext MySqlContext { get; set; }
        internal MySqlContext Db { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var sqlConnectionString = Configuration["PostgreSqlConnectionString"];
            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddTransient<MySqlContext>(_ => new MySqlContext(Configuration["ConnectionStrings:DefaultConnectionSql"]));
            // using var cmd = Db.Connection.CreateCommand();
            // cmd.CommandText = "DELETE FROM `testtable` WHERE `ID` = 1;";
            // cmd.ExecuteNonQueryAsync();
            //services.AddDbContext<MySqlContext>(options =>options.UseMySql(Configuration.GetConnectionString("DefaultConnectionSql")));
            // var cmd = this.MySqlContext.Connection.CreateCommand() as MySqlCommand;
            // var xmlquery="DELETE FROM testtable WHERE ID='1';";
            // cmd.CommandText =xmlquery;
            // cmd.ExecuteNonQueryAsync();
            // MySqlDataReader reader = cmd.ExecuteReader();
            // Console.WriteLine(reader);
            services.AddScoped<CurrencyDefinitionService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
