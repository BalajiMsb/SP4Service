using Microsoft.EntityFrameworkCore;
using Sp4service.Vo;
namespace Sp4service.Context
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