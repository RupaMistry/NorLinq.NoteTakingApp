using Microsoft.EntityFrameworkCore;
using NorLinq.NoteTakingApp.Domain;

namespace NorLinq.NoteTakingApp.Infrastructure
{
    public class NotesAppContext : DbContext
    {
        public NotesAppContext(DbContextOptions<NotesAppContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; } = null!;
    }
}
