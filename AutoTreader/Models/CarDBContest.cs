using Microsoft.EntityFrameworkCore;

namespace AutoTreader.Models
{
    public class CarDBContest : DbContext
    {
        public CarDBContest()
        {

        }

        public CarDBContest(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=autotrader;user=root;password=;SslMode=None");
        }
    }
}
