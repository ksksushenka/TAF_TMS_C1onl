using AngleSharp.Text;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CasesTests : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public int caseId { get; set; }

        [Test, Order(1)]
        public void AddCaseTest()
        {
            var expectedCase = new Case();

            expectedCase.Title = "Title of Case Ks";

            var actualCase = _caseService.AddCase(expectedCase, 1);
            _logger.Info("Actual Case: " + actualCase.ToString());

            var json = actualCase.Content;
            var jsonObject = JObject.Parse(json);

            caseId = jsonObject.SelectToken("$.id").Value<int>();

            string title = jsonObject.SelectToken("$.title").Value<string>();
            _logger.Info("jsonObject -> title: " + title);

            Assert.That(title, Is.EqualTo(expectedCase.Title));
        }

        [Test,Order(2)]
        public void GetCaseTest()
        {
            var actualCase = _caseService.GetCase(caseId);

            var json = actualCase.Content;
            var jsonObject = JObject.Parse(json);

            int id = jsonObject.SelectToken("$.id").Value<int>();

            Assert.That(id, Is.EqualTo(caseId));
        }

        [Test, Order(3)]
        public void UpdateCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = "Title of Case Ks UPD";
            expectedCase.SectionId = 2;

            var actualCase = _caseService.UpdateCase(expectedCase, caseId);
            _logger.Info("Actual Case: " + actualCase.ToString());

            var json = actualCase.Content;
            var jsonObject = JObject.Parse(json);

            string title = jsonObject.SelectToken("$.title").Value<string>();
            _logger.Info("jsonObject -> title: " + title);

            int sectionId = jsonObject.SelectToken("$.section_id").Value<int>();
            _logger.Info("jsonObject -> title: " + title);

            Assert.That(title, Is.EqualTo(expectedCase.Title));
            Assert.That(sectionId, Is.EqualTo(expectedCase.SectionId));
        }

        [Test, Order(4)]
        public void DeleteCaseTest()
        {
            var actualCase = _caseService.DeleteCase(caseId);

            Assert.That("OK", Is.EqualTo(actualCase.StatusCode.ToString()));
        }
    }
}
