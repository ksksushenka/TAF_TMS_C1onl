using AngleSharp.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using System.Data.Common;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBases;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CasesTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private DataBaseConnector _dataBaseConnector;
        public int caseId { get; set; }
        public Case caseForDb { get; set; }

        [OneTimeSetUp]
        public void setUp()
        {
            _dataBaseConnector = new DataBaseConnector();
        }

        [Test, Order(1)]
        public void AddCaseTest()
        {           
            var expectedCase = new Case { Title = "Title of Case Ks"};

            var actualCase = _caseService.AddCase(expectedCase, 1);
            _logger.Info("Actual Case: " + actualCase.ToString());

            var json = actualCase.Content;
            var jsonObject = JObject.Parse(json);

            caseId = jsonObject.SelectToken("$.id").Value<int>();

            caseForDb = new Case { Id = caseId, Title = expectedCase.Title, SectionId = 1 };

            var caseDb = _dataBaseConnector.Cases.Add(caseForDb);
            _dataBaseConnector.SaveChanges();
            _logger.Info($"Title: {_dataBaseConnector.Cases.Find(caseDb.Entity.Id)?.Title}");

            Assert.That(_dataBaseConnector.Cases.Find(caseId)?.Title, Is.EqualTo(expectedCase.Title));
        }

        [Test,Order(2)]
        public void GetCaseTest()
        {
            Assert.That(_dataBaseConnector.Cases.Find(caseId)?.Id, Is.EqualTo(caseId));
        }

        [Test, Order(3)]
        public void UpdateCaseTest()
        {
            var expectedCase = new Case { Title = "Title of Case Ks UPD" };

            var actualCase = _caseService.UpdateCase(expectedCase, caseId);
            _logger.Info("Actual Case: " + actualCase.ToString());

            caseForDb.Title = expectedCase.Title;
            var caseDb = _dataBaseConnector.Cases.Update(caseForDb);
            _dataBaseConnector.SaveChanges();
            _logger.Info($"Title: {_dataBaseConnector.Cases.Find(caseDb.Entity.Id)?.Title}");

            Assert.That(_dataBaseConnector.Cases.Find(caseId)?.Title, Is.EqualTo(expectedCase.Title));
        }

        [Test, Order(4)]
        public void DeleteCaseTest()
        {
            var actualCase = _caseService.DeleteCase(caseId);

            _dataBaseConnector.Cases.Remove(caseForDb);
            _dataBaseConnector.SaveChanges();

            Assert.That("OK", Is.EqualTo(actualCase.StatusCode.ToString()));
        }
    }
}
