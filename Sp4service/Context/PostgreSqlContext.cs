using Microsoft.EntityFrameworkCore;
using Sp4service.vo;
namespace Sp4service.context
{
    public class PostgreSqlContext:DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options):base(options){

        }
        public DbSet<CurrencyDefinition> currencyDefinition {get; set;}
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }
        public override int SaveChanges(){
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}