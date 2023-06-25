using Microsoft.EntityFrameworkCore;
using RChat.DAL.Entities;

namespace RChat.DAL.Context
{
    public class RChatContext : DbContext
    {
        public RChatContext(DbContextOptions<RChatContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ChatEntity> Chats { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public RChatContext()
        {
            Database.EnsureCreated();      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.UserId);
            modelBuilder.Entity<UserEntity>().HasAlternateKey(u => u.Login);
            modelBuilder.Entity<ChatEntity>().HasKey(c => c.ChatId);
            modelBuilder.Entity<MessageEntity>().HasKey(v => v.MessageId);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RCHAT;Username=postgres;Password=stud");
        //}
    }
}
