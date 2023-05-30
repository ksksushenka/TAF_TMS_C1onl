using System.Reflection;
using RestSharp;

namespace TAF_TMS_C1onl.Tests.API;

public class ReqresTests
{
    [Test]
    public void GetUser()
    {
        // Create a RestClient instance
        var client = new RestClient("https://reqres.in");
        
        // Create a RestRequest with endpoint and type
        var request = new RestRequest("/api/users/2", Method.Get);
        
        // Execute the request and get the response
        var response = client.Execute(request);
        
        // Check if the request was successful
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Request failed: {response.ErrorMessage}");
        }
    }

    [Test]
    public void CreateUser1()
    {
        // Create a RestClient instance
        var client = new RestClient("https://reqres.in");

        // Create a RestRequest with endpoint and type
        var request = new RestRequest("/api/users", Method.Post);

        // Set the request parameter
        request.AddHeader("Content-Type", "application/json");
        
        // Add body
        var body = "{\"name\": \"morpheus\",\"job\": \"leader\"}";
        request.AddBody(body);
        
        // Execute the request and get the response
        var response = client.Execute(request);
        
        // Check if the request was successful
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Request failed: {response.ErrorMessage}");
        }
    }

    [Test]
    public void CreateUser2()
    {
        // Create a RestClient instance
        var client = new RestClient("https://reqres.in");

        // Create a RestRequest with endpoint and type
        var request = new RestRequest("/api/users", Method.Post);

        // Set the request parameter
        request.AddHeader("Content-Type", "application/json");
        
        // Add body
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
                                    + Path.DirectorySeparatorChar + "CreateUser.json");

        request.AddBody(json);
        
        // Execute the request and get the response
        var response = client.Execute(request);
        
        // Check if the request was successful
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Request failed: {response.ErrorMessage}");
        }
    }

    [Test]
    public void CreateUser3()
    {
        // Create a RestClient instance
        var client = new RestClient("https://reqres.in");

        // Create a RestRequest with endpoint and type
        var request = new RestRequest("/api/users", Method.Post);

        // Set the request parameter
        request.AddHeader("Content-Type", "application/json");
        
        // Add body
        var body = new
        {
            Name = "Ivan",
            Job = "developer"
        };
        request.AddJsonBody(body);
        
        // Execute the request and get the response
        var response = client.Execute(request);
        
        // Check if the request was successful
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Request failed: {response.ErrorMessage}");
        }
    }

    [Test]
    public void CreateUser4()
    {
        // Create a RestClient instance
        var client = new RestClient("https://reqres.in");

        // Create a RestRequest with endpoint and type
        var request = new RestRequest("/api/users", Method.Post);

        // Set the request parameter
        request.AddHeader("Content-Type", "application/json");
        
        // Add body
        var body = new Dictionary<string, object>()
        {
            { "name" , "Ivan 1"},
            { "job" , "developer 1" }
        };
        request.AddJsonBody(body);
        
        // Execute the request and get the response
        var response = client.Execute(request);
        
        // Check if the request was successful
        if (response.IsSuccessful)
        {
            Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Request failed: {response.ErrorMessage}");
        }
    }
}