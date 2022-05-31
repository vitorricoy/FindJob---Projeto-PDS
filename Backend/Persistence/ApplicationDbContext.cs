using Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobCandidateModel>().HasKey(cm => new { cm.CandidateId, cm.JobId });
            modelBuilder.Entity<JobRequirementModel>().HasKey(rm => new { rm.SkillId, rm.JobId });
        }

        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserProficiencyModel> UserSkills { get; set; }
        public DbSet<JobRequirementModel> JobSkills { get; set; }
        public DbSet<JobCandidateModel> JobCandidates { get; set; }
    }
}