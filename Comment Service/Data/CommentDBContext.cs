using Comment_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Comment_Service.Data
{
    public class CommentDBContext : DbContext
    {
        public CommentDBContext(DbContextOptions<CommentDBContext>options):base(options) { }
        public DbSet<Comment> comments { get; set; }
        
    }
}
