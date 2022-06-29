using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Persistence.Tests
{
    public class SkillRepositoryTests
    {
        ApplicationDbContext dbContextMock;

        ISkillRepository skillRepository;

        public SkillRepositoryTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase("SkillRepositoryTests" + Guid.NewGuid().ToString())
                 .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                 .Options;

            dbContextMock = new ApplicationDbContext(_contextOptions);

            dbContextMock.ChangeTracker.Clear();

            dbContextMock.Database.EnsureDeleted();
            dbContextMock.Database.EnsureCreated();

            skillRepository = new SkillRepository(dbContextMock);
        }


        [Fact]
        public void TestCreateSkillWithNewSkill()
        {
            var response = skillRepository.CreateNewSkill(new Skill("Teste", "teste"));

            var createdSkill = dbContextMock.Skills.FirstOrDefault(s => s.NormalizedName == "teste");

            Assert.Equal("Teste", response.Name);
            Assert.Equal("teste", response.NormalizedName);

            Assert.NotNull(createdSkill);
            Assert.Equal("Teste", createdSkill.Name);
            Assert.Equal("teste", createdSkill.NormalizedName);
        }

        [Fact]
        public void TestCreateSkillWithExistentSkill()
        {
            skillRepository.CreateNewSkill(new Skill("Teste", "teste"));

            var response = skillRepository.CreateNewSkill(new Skill("Teste", "teste"));

            var createdSkills = dbContextMock.Skills.Where(s => s.NormalizedName == "teste").ToList();

            Assert.Equal("Teste", response.Name);
            Assert.Equal("teste", response.NormalizedName);

            Assert.Single(createdSkills);
            
            Assert.Equal("Teste", createdSkills[0].Name);
            Assert.Equal("teste", createdSkills[0].NormalizedName);
        }

        [Fact]
        public void TestGetAllSkillsWithNoSkills()
        {
            var response = skillRepository.GetAllSkills();

            Assert.Empty(response);
        }

        [Fact]
        public void TestGetAllSkillsWithManySkills()
        {
            skillRepository.CreateNewSkill(new Skill("Teste1", "teste1"));
            skillRepository.CreateNewSkill(new Skill("Teste2", "teste2"));

            var response = skillRepository.GetAllSkills();

            Assert.Contains(response, s => s.NormalizedName == "teste1");
            Assert.Contains(response, s => s.NormalizedName == "teste2");
        }
    }
}
