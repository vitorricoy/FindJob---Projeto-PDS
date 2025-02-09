﻿using Backend.API.Controllers.Models;
using Backend.Controllers;
using Backend.Domain.Entity;
using Backend.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.API.Controllers
{
    public class SkillControllerTest
    {
        public SkillControllerTest()
        {

        }

        [Fact]
        public void TestGetAllSkillsSuccess()
        {
            ISkillService skillServiceMock = Substitute.For<ISkillService>();
            Skill skill1 = new("teste1", "teste1");
            Skill skill2 = new("teste2", "teste2");
            Skill skill3 = new("teste3", "teste3");
            skillServiceMock.GetAllSkills().Returns(args => new List<Skill>() { skill1, skill2, skill3 });
            SkillController controller = new(skillServiceMock);
            OkObjectResult? actionResult = controller.GetAllSkills() as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            List<Skill>? responseObject = actionResult?.Value as List<Skill>;
            Assert.Equal(new List<Skill>() { skill1, skill2, skill3 }, responseObject);
        }

        [Fact]
        public void TestGetAllSkillsError()
        {
            ISkillService skillServiceMock = Substitute.For<ISkillService>();
            skillServiceMock.GetAllSkills().Returns(args => { throw new Exception(); });
            SkillController controller = new(skillServiceMock);
            ObjectResult? actionResult = controller.GetAllSkills() as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

        [Fact]
        public void TestCreateSkillsSuccess()
        {
            ISkillService skillServiceMock = Substitute.For<ISkillService>();
            Skill skill1 = new Skill("teste1", "teste1");
            skillServiceMock.CreateNewSkill(Arg.Any<string>()).Returns(args => skill1);
            SkillController controller = new(skillServiceMock);
            CreateSkillInput input = new(skill1.Name);
            OkObjectResult? actionResult = controller.CreateNewSkill(input) as OkObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(200, actionResult?.StatusCode);

            Skill? responseObject = actionResult?.Value as Skill;
            Assert.Equal(skill1, responseObject);
        }

        [Fact]
        public void TestCreateSkillsError()
        {
            ISkillService skillServiceMock = Substitute.For<ISkillService>();
            skillServiceMock.CreateNewSkill(Arg.Any<string>()).Returns(args => { throw new Exception(); });
            SkillController controller = new(skillServiceMock);
            CreateSkillInput input = new("teste");
            ObjectResult? actionResult = controller.CreateNewSkill(input) as ObjectResult;

            Assert.NotNull(actionResult);
            Assert.Equal(500, actionResult?.StatusCode);
        }

    }
}
