using Gateway_Services.Interfaces;
using Gateway_Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway_Services.Implementation
{
    public class ProcessService : IProcessService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        public ProcessService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _endpoint = _configuration["ProcessEndpoint"];
        }

        public async Task<CheckResultModel> CheckAnswer(CheckAnswerViewModel viewModel)
        {
            var response = await _httpClient.PostAsync(_endpoint
                                                       + "/TestProcess/CheckAnswer",
                new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json"));

            if (response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException();
            }

            var model = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CheckResultModel>(model);

            return result;
        }

        public async Task<ICollection<Question>> MixQuestions(Guid testId)
        {
            var response = await _httpClient.GetAsync(_endpoint
                                                       + "/TestProcess/MixQuestions?testId=" + testId);

            if (response.StatusCode == HttpStatusCode.InternalServerError ||
                response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException();
            }

            var result = JsonConvert.DeserializeObject<ICollection<Question>>(await response.Content.ReadAsStringAsync());

            return result;
        }
    }
}