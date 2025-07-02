using Microsoft.EntityFrameworkCore;
using ModernAPI.DataAccess.Model;

namespace ModernAPI.DataAccess.Context
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
