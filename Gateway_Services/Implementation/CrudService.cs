using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gateway_Services.Interfaces;
using Gateway_Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gateway_Services.Implementation
{
    public class CrudService : ICrudService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        public CrudService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _endpoint = _configuration["CrudEndpoint"];
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Answer");

            var answers = JsonConvert.DeserializeObject<List<Answer>>(response);

            return answers;
        }

        public async Task<bool> DeleteAnswerAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/Answer/" + id);
            return true;
        }

        public async Task<bool> UpdateAnswerAsync(Answer obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/Answer/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateAnswerAsync(Answer obj)
        {
            await _httpClient.PostAsync(_endpoint + "/Answer/",
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
        }

        public async Task<Answer> GetAnswerById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Answer/"+id);

            var result = JsonConvert.DeserializeObject<Answer>(response);

            return result;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Question");

            var Questions = JsonConvert.DeserializeObject<List<Question>>(response);

            return Questions;
        }

        public async Task<bool> DeleteQuestionAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/Question/" + id);
            return true;
        }

        public async Task<bool> UpdateQuestionAsync(Question obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/Question/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateQuestionAsync(Question obj)
        {
            await _httpClient.PostAsync(_endpoint + "/Question/",
                new StringContent(JsonConvert.SerializeObject(obj)));
        }

        public async Task<Question> GetQuestionById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Question/" + id);

            var result = JsonConvert.DeserializeObject<Question>(response);

            return result;
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Test");

            var Tests = JsonConvert.DeserializeObject<List<Test>>(response);

            return Tests;
        }

        public async Task<bool> DeleteTestAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/Test/" + id);
            return true;
        }

        public async Task<bool> UpdateTestAsync(Test obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/Test/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateTestAsync(Test obj)
        {
            await _httpClient.PostAsync(_endpoint + "/Test/",
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
        }

        public async Task<Test> GetTestById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/Test/" + id);

            var result = JsonConvert.DeserializeObject<Test>(response);

            return result;
        }

        public async Task<IEnumerable<TestTheme>> GetAllTestThemesAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/TestTheme");

            var TestThemes = JsonConvert.DeserializeObject<List<TestTheme>>(response);

            return TestThemes;
        }

        public async Task<bool> DeleteTestThemeAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/TestTheme/" + id);
            return true;
        }

        public async Task<bool> UpdateTestThemeAsync(TestTheme obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/TestTheme/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateTestThemeAsync(TestTheme obj)
        {
            await _httpClient.PostAsync(_endpoint + "/TestTheme/",
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
        }

        public async Task<TestTheme> GetTestThemeById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/TestTheme/" + id);

            var result = JsonConvert.DeserializeObject<TestTheme>(response);

            return result;
        }


    }
}