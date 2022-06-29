using Backend.Domain.Entity;
using Backend.Domain.Exceptions;
using Backend.Domain.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Domain.Service.Tests
{
    public class SkillServiceTests
    {
        List<Skill> mockRepo;

        ISkillRepository skillRepositoryMock;

        ISkillService skillService;

        public SkillServiceTests()
        {
            mockRepo = new List<Skill>();
            
            skillRepositoryMock = Substitute.For<ISkillRepository>();
            
            skillRepositoryMock.GetAllSkills().Returns(mockRepo);
            
            skillRepositoryMock.CreateNewSkill(Arg.Any<Skill>()).
                Returns(args => {
                    var argSkill = (Skill)args[0];
                    var found = mockRepo.Find(skill => skill.NormalizedName == argSkill.NormalizedName);
                    if(found != null)
                    {
                        return found; 
                    }
                    mockRepo.Add(argSkill);
                    return argSkill;
                 });
            skillService = new SkillService(skillRepositoryMock);
        }
        
        [Fact]
        public void TestCreateSkillWithNewSkill()
        {
            Skill response = skillService.CreateNewSkill("C++");
            Assert.Equal("C++", response.Name);
            Assert.Equal("C++", response.NormalizedName);

            mockRepo.Clear();
        }

        [Fact]
        public void TestCreateSkillWithSameNormalizedName()
        {
            skillService.CreateNewSkill("JaVa");

            Skill response = skillService.CreateNewSkill("jAvA");

            Assert.Equal("JaVa", response.Name);

            Assert.Equal("java", response.NormalizedName);

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetAllSkillsWithNoSkills()
        {
            List<Skill> response = skillService.GetAllSkills();

            Assert.Equal(new List<Skill>(), response);

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetAllSkillsWithDifferentSkills()
        {
            skillService.CreateNewSkill("C++");

            skillService.CreateNewSkill("Java");
            
            List<Skill> response = skillService.GetAllSkills();

            Assert.Equal(new List<Skill>() { new Skill("C++", "c++"), new Skill("Java", "java") }, response);

            mockRepo.Clear();
        }

        [Fact]
        public void TestGetAllSkillsWithRepeatedSkills()
        {
            skillService.CreateNewSkill("C++");

            skillService.CreateNewSkill("Java");
            
            skillService.CreateNewSkill("C + +");

            skillService.CreateNewSkill("jAvA");

            List<Skill> response = skillService.GetAllSkills();

            Assert.Equal(new List<Skill>() { new Skill("C++", "c++"), new Skill("Java", "java") }, response);

            mockRepo.Clear();
        }
    }

}
