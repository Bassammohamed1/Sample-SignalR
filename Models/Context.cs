using Microsoft.EntityFrameworkCore;

namespace SignalR.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Chat> Chats { get; set; }
    }
}