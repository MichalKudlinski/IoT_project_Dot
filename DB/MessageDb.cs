using Microsoft.EntityFrameworkCore;
using mkproject.Models;
namespace mkproject.DB
{
    public class MessageDb : DbContext
    {
        public MessageDb(DbContextOptions<MessageDb> options) : base(options)
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; } // Add this DbSet for ChatRoom

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary key for ChatMessage entity
            modelBuilder.Entity<ChatMessage>().HasKey(cm => cm.Id);

            // Configure one-to-many relationship between ChatRoom and ChatMessage
            modelBuilder.Entity<ChatMessage>()
                .HasOne(cm => cm.ChatRoom)
                .WithMany(cr => cr.ChatMessages)
                .HasForeignKey(cm => cm.ChatRoomName)
                .OnDelete(DeleteBehavior.Cascade); // Example: Cascade delete for messages if room is deleted
        }
    }
}

