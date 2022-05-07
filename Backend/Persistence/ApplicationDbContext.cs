using Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}