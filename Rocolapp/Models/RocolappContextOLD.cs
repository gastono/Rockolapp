using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Rocolapp.Models
{
    public class RocolappContextOLD : DbContext
    {
        public RocolappContextOLD()
            : base("Rocolapp")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<RocolappContext>(null);
        }

        public DbSet<RocolappUser> RocolappUsers { get; set; }
        public DbSet<Screen> Screens { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}