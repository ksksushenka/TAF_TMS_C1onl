using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Tests.API
{
    public class MilestonesTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public int milestoneId { get; set; }

        [Test, Order(1)]
        public void AddMilestoneTest()
        {
            var expectedMilestone = new Milestone();

            expectedMilestone.Name = "Name of milestone Ks";
            expectedMilestone.StartOn = 1391968184;

            var actualMilestone = _milestoneService.AddMilestone(expectedMilestone, 142);
            _logger.Info("Actual Milestone: " + actualMilestone.ToString());

            var json = actualMilestone.Content;
            var actual = JsonConvert.DeserializeObject<Project>(json);

            Assert.AreEqual(expectedMilestone.Name, actual.Name);

            //var json = actualMilestone.Content;
            //var jsonObject = JObject.Parse(json);

            //milestoneId = jsonObject.SelectToken("$.id").Value<int>();

            //string name = jsonObject.SelectToken("$.name").Value<string>();
            //_logger.Info("jsonObject -> name: " + name);

            //int startOn = jsonObject.SelectToken("$.start_on").Value<int>();
            //_logger.Info("jsonObject -> startOn: " + startOn);

            //Assert.That(name, Is.EqualTo(expectedMilestone.Name));
            //Assert.That(startOn, Is.EqualTo(expectedMilestone.StartOn));
        }

        [Test, Order(2)]
        public void GetMilestoneTest()
        {
            var actualMilestone = _milestoneService.GetMilestone(milestoneId);

            var json = actualMilestone.Content;
            var jsonObject = JObject.Parse(json);

            int id = jsonObject.SelectToken("$.id").Value<int>();

            Assert.That(id, Is.EqualTo(milestoneId));
        }

        [Test, Order(3)]
        public void UpdateMilestoneTest()
        {
            var expectedMilestone = new Milestone();
            expectedMilestone.Name = "Name of milestone Ks";
            expectedMilestone.StartOn = 1391918184;

            var actualMilestone = _milestoneService.UpdateMilestone(expectedMilestone, milestoneId);
            _logger.Info("Actual Milestone: " + actualMilestone.ToString());

            var json = actualMilestone.Content;
            var jsonObject = JObject.Parse(json);

            int startOn = jsonObject.SelectToken("$.start_on").Value<int>();
            _logger.Info("jsonObject -> startOn: " + startOn);

            Assert.That(startOn, Is.EqualTo(expectedMilestone.StartOn));
        }

        [Test, Order(4)]
        public void DeleteMilestoneTest()
        {
            var actualMilestone = _milestoneService.DeleteMilestone(milestoneId);

            Assert.That("OK", Is.EqualTo(actualMilestone.StatusCode.ToString()));
        }
    }
}