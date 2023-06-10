using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Services
{
    public class MilestoneService : BaseService
    {
        public MilestoneService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetMilestone(int milestoneId)
        {
            var request = new RestRequest(Endpoints.GET_MILESTONE)
                .AddUrlSegment("milestone_id", milestoneId);

            return _apiClient.Execute(request);
        }

        public RestResponse AddMilestone(Milestone milestone, int projectId)
        {
            var request = new RestRequest(Endpoints.ADD_MILESTONE, Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(milestone);

            return _apiClient.Execute(request);
        }

        public RestResponse UpdateMilestone(Milestone milestone, int milestoneId)
        {
            var request = new RestRequest(Endpoints.UPDATE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestoneId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(milestone);

            return _apiClient.Execute(request);
        }

        public RestResponse DeleteMilestone(int milestoneId)
        {
            var request = new RestRequest(Endpoints.DELETE_MILESTONE, Method.Post)
                .AddUrlSegment("milestone_id", milestoneId)
                .AddHeader("Content-Type", "application/json");

            return _apiClient.Execute(request);
        }
    }
}
