using Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}