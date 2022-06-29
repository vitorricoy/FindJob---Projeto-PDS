using Backend.Domain.Entity;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Tests
{
    public static class TestingHelper
    {
        public static void CreateUserInDatabase(User user, ApplicationDbContext context)
        {
            context.Users.Add(UserModel.FromDomainObject(user));
            context.UserSkills.AddRange(UserProficiencyModel.FromUserDomainObject(user));
            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public static void CreateSkillsInDatabase(Skill skill, ApplicationDbContext context)
        {
            context.Skills.Add(SkillModel.FromDomainObject(skill));
            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public static void CreateJobInDatabase(Job job, ApplicationDbContext context)
        {
            context.Jobs.Add(JobModel.FromDomainObject(job));

            context.JobSkills.AddRange(JobRequirementModel.FromJobDomainObject(job));
            context.JobCandidates.AddRange(JobCandidateModel.FromJobDomainObject(job));

            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public static void CreateMessageInDatabase(Message message, ApplicationDbContext context)
        {
            context.Messages.Add(MessageModel.FromDomainObject(message));

            context.SaveChanges();

            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }

        public static void ClearDatabaseAttachedEntities(ApplicationDbContext context)
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        } 
    }
}
