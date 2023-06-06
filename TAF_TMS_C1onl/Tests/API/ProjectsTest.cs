using AngleSharp.Text;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API;

public class ProjectsTest : BaseApiTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    [Test]
    public void GetProjectTest_1()
    {
        var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
            .AddUrlSegment("project_id", "1");
        var response = _apiClient.Execute(request);
        _logger.Info(response.Content.NormalizeLineEndings());

        var json = response.Content;
        
        // Выполним десериализацию JSON-строки в объект JObject
        var jsonObject1 = JObject.Parse(json);
        var jsonObject2 = JsonHelper.FromJson(json);
        
        // Использование JsonPath для извлечения занчения из объекта
        var value = jsonObject1.SelectToken("$.name");
        _logger.Info("jsonObject1 -> name: " + value);

        var value2 = jsonObject2.SelectToken("$.name");
        _logger.Info("jsonObject2 -> name: " + value);
    }

    [Test]
    public void GetProjectTest_2()
    {
        var json = _projectService.GetProject("1").Content;
        
        // Выполним десериализацию JSON-строки в объект JObject
        var jsonObject1 = JObject.Parse(json);
        var jsonObject2 = JsonHelper.FromJson(json);
        
        // Использование JsonPath для извлечения занчения из объекта
        var value = jsonObject1.SelectToken("$.name");
        _logger.Info("jsonObject1 -> name: " + value);

        var value2 = jsonObject2.SelectToken("$.name");
        _logger.Info("jsonObject2 -> name: " + value);
    }

    [Test]
    public void GetProjectTest_3()
    {
        var actualProject = _projectService.GetAsProject("1");
        _logger.Info("jsonObject2 -> name: " + actualProject.Name);
    }

    [Test]
    public void GetProjectTest_4()
    {
        var json = _projectService.GetProjectAsync("1").Result.Content;
        
        // Выполним десериализацию JSON-строки в объект JObject
        var jsonObject1 = JObject.Parse(json);
        var jsonObject2 = JsonHelper.FromJson(json);
        
        // Использование JsonPath для извлечения занчения из объекта
        var value = jsonObject1.SelectToken("$.name");
        _logger.Info("jsonObject1 -> name: " + value);

        var value2 = jsonObject2.SelectToken("$.name");
        _logger.Info("jsonObject2 -> name: " + value);
    }

    [Test]
    public void GetProjectTest_5()
    {
        var actualProject = _projectService.GetAsProjectAsync("1");
        _logger.Info("jsonObject2 -> name: " + actualProject.Name);
    }

    [Test]
    public void AddProjectTest_1()
    {
        var expectedProject = new Project();
        expectedProject.Name = "Test Project 2";
        expectedProject.Announcement = "Description Test Project 2";
        expectedProject.SuiteMode = 2;
        
        var actualProject = _projectService.AddProjectAsync(expectedProject);
        _logger.Info("Actual Project: " + actualProject.Result.ToString());
        
        Assert.AreEqual(expectedProject.Name, actualProject.Result.Name);
    }
}