using NLog;
using RestSharp;
using RestSharp.Authenticators;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Clients;

public class ApiClient
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private readonly RestClient _restClient;

    public ApiClient()
    {
        var options = new RestClientOptions(Configurator.AppSettings.URL)
        {
            Authenticator = new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password),
            ThrowOnAnyError = true,
            MaxTimeout = 10000
        };

        _restClient = new RestClient(options);
    }

    public RestResponse Execute(RestRequest request)
    {
        _logger.Info("Request: " + request.Resource);
        var response = _restClient.Execute(request);
        
        _logger.Info("Response Status: " + response.ResponseStatus);
        _logger.Info("Response Body: " + response.Content);

        return response;
    }

    public T Execute<T>(RestRequest request) where T : new()
    {
        _logger.Info("Request: " + request.Resource);
        var response = _restClient.Execute<T>(request);
        
        _logger.Info("Response Status: " + response.ResponseStatus);
        _logger.Info("Response Body: " + response.Content);

        return response.Data;
    }

    public async Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        _logger.Info("Request: " + request.Resource);
        var response = await _restClient.ExecuteAsync(request);
        
        _logger.Info("Response Status: " + response.ResponseStatus);
        _logger.Info("Response Body: " + response.Content);

        return response;
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
    {
        _logger.Info("Request: " + request.Resource);
        var response = await _restClient.ExecuteAsync<T>(request);
        
        _logger.Info("Response Status: " + response.ResponseStatus);
        _logger.Info("Response Body: " + response.Content);

        return response.Data;
    }
    
    
}