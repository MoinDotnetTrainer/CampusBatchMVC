using Microsoft.EntityFrameworkCore;

namespace WebAppAarohi28052024.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }


        public virtual DbSet<CurdModel> curdmodel { get; set; }


    }
}
