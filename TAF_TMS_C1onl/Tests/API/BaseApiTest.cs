using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Services;

namespace TAF_TMS_C1onl.Tests.API;

public class BaseApiTest
{
    protected ApiClient _apiClient;
    protected ProjectService _projectService;
    protected CaseService _caseService;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _apiClient = new ApiClient();
        _projectService = new ProjectService(_apiClient);
        _caseService = new CaseService(_apiClient);
    }
}