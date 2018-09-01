namespace FDMC.Data
{
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;

    public class CatContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Database=Cats_MVC;Integrated Security=True");
                //optionsBuilder.UseSqlServer("Data Source=MS-PC\\SQLEXPRESS;Database=Cats_MVC;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}