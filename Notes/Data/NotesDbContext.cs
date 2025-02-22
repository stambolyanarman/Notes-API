using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Data
{
    public class NotesDbContext(DbContextOptions<NotesDbContext> options) : DbContext(options)
    {
        public DbSet<Note> Notes { get; set; }
    }
}
