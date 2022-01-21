using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace OnlineChatApp.Models
{
    public class OnlineChatAppDb : DbContext
    {
        public DbSet<User>? Users => Set<User>();
        public DbSet<FriendRequest>? FriendRequests => Set<FriendRequest>();

        private readonly IConfiguration Configuration;

        public OnlineChatAppDb(DbContextOptions<OnlineChatAppDb> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(Configuration["my_env"] == "Development")
            {
                Console.WriteLine("Development");
                optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=onlinechatapp;Username=postgres;Password=daniel23082000");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.UserRole).HasConversion<string>();
            modelBuilder.Entity<FriendRequest>().Property(u => u.FriendRequestStatus).HasConversion<string>();
            modelBuilder.Entity<User>().Property(u=>u.Gender).HasConversion<string>();
            // modelBuilder.Entity<UserFriendRequest>().HasKey(u => new {u.UserId, u.FriendRequestId});
            modelBuilder.Entity<FriendRequest>().HasOne(u => u.FriendRequestFrom).WithMany(u=>u.FriendRequest).HasForeignKey(u=>u.FriendRequestFromId);
            modelBuilder.Entity<FriendRequest>().HasOne(u => u.FriendRequestTo).WithMany().HasForeignKey(u=>u.FriendRequestToId);
        }
    }
}