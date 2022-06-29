using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using Xunit;

namespace Backend.Tests
{
    public class SkillTests
    {
        readonly SkillController skillController;
        readonly ApplicationDbContext context;

        public SkillTests()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SkillTests")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            SkillRepository skillRepository = new(context);

            SkillService skillService = new(skillRepository);

            skillController = new SkillController(skillService);
        }

        [Fact]
        public void TestGetAllSkills()
        {
            Skill teste1 = new("Teste1", "teste1");
            Skill teste2 = new("teste2", "teste2");
            Skill teste3 = new("teste 3", "teste3");
            TestingHelper.CreateSkillsInDatabase(teste1, context);
            TestingHelper.CreateSkillsInDatabase(teste2, context);
            TestingHelper.CreateSkillsInDatabase(teste3, context);

            OkObjectResult? actionResult = skillController.GetAllSkills() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Skill>? responseObject = actionResult?.Value as List<Skill>;
            Assert.NotNull(responseObject);
            Assert.Equal(3, responseObject?.Count);
            Assert.Equal(teste1, responseObject?[0]);
            Assert.Equal(teste2, responseObject?[1]);
            Assert.Equal(teste3, responseObject?[2]);

        }

        [Fact]
        public void TestCreateSkill()
        {
            CreateSkillInput input = new("Teste");
            OkObjectResult? actionResult = skillController.CreateNewSkill(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Skill? responseObject = actionResult?.Value as Skill;
            Assert.NotNull(responseObject);

            Assert.Equal("Teste", responseObject?.Name);
            Assert.Equal("teste", responseObject?.NormalizedName);
        }
    }
}
