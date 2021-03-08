using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gateway_Services.Interfaces;
using Gateway_Services.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gateway_Services.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        public AuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _endpoint = _configuration["AuthorizationEndpoint"];
        }

        public async Task<string> Login(string login, string password)
        {
            var response = await 
                _httpClient.PostAsync
                    (_endpoint+ "/Authentication/Login?login="+login+"&password="+password, new StringContent(""));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return "";
            }

            return await response.Content.ReadAsStringAsync();

        }

        public async Task<bool> Register(string login, string password, string firstName, string lastName)
        {
            if (login.Length < 4 || password.Length < 4 || firstName.Length < 4 || lastName.Length < 4)
            {
                return false;
            } 

            var response = await
                _httpClient.PostAsync
                    (_endpoint + "/Authentication/Register?login=" + login + 
                     "&password=" + password +
                    "&firstName="+firstName +
                    "&lastName="+lastName, new StringContent(""));

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;

        }

        public async Task<Guid> GetUserIdByLogin(string login)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/UserManagement/GetIdByLogin?login="+login);

            var id = Guid.Parse(response);

            return id;
        }

        public async Task<ICollection<TestAttempt>> GetUserAttempts(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/UserManagement/GetAttempts?id=" + id);

            var attempts = JsonConvert.DeserializeObject<ICollection<TestAttempt>>(response);

            return attempts;
        }

        public async Task<ICollection<TestAttempt>> ChangeUserRole(Guid id, string role)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/UserManagement/ChangeRole?userId=" + id + "&role=" + role);

            var attempts = JsonConvert.DeserializeObject<ICollection<TestAttempt>>(response);

            return attempts;
        }

        public async Task AddAttemptToUser(Guid id, Guid testId)
        {
            await _httpClient.GetStringAsync(
                _endpoint + "/UserManagement/AddUserAttempt?userId=" + id + "&testId=" + testId);
        }

        public async Task<bool> ChangeUserLogin(Guid userId, string newLogin)
        {
            var response = await _httpClient.GetAsync(_endpoint + "/UserManagement/ChangeUserLogin?userId=" + userId + "&newLogin=" + newLogin);

            var result = response.StatusCode;

            if (result == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ChangeUserPassword(Guid userId, string newLogin)
        {
            var response = await _httpClient.GetAsync(_endpoint + "/UserManagement/ChangeUserPassword?userId=" + userId + "&newPassword=" + newLogin);

            var result = response.StatusCode;

            if (result == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ChangeUserFirstName(Guid userId, string newFirstName)
        {
            var response = await _httpClient.GetAsync(_endpoint + "/UserManagement/ChangeUserFirstName?userId=" + userId + "&newFirstName=" + newFirstName);

            var result = response.StatusCode;

            if (result == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ChangeUserLastName(Guid userId, string newLastName)
        {
            var response = await _httpClient.GetAsync(_endpoint + "/UserManagement/ChangeUserLastName?userId=" + userId + "&newLastName=" + newLastName);

            var result = response.StatusCode;

            if (result == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> SaveAttemptToUser(Guid userId, TestAttempt attempt)
        {
            var serialized = JsonConvert.SerializeObject(attempt);
            var response = await _httpClient.PostAsync(_endpoint + "/UserManagement/SaveAttemptToUser?userId=" + userId, new StringContent(serialized, Encoding.UTF8, "application/json") );

            var result = response.StatusCode;

            if (result == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return true;
        }



        public async Task<IEnumerable<TestAttempt>> GetAllTestAttemptsAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/TestAttemptCrud");

            var TestAttempts = JsonConvert.DeserializeObject<List<TestAttempt>>(response);

            return TestAttempts;
        }

        public async Task<bool> DeleteTestAttemptAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/TestAttemptCrud/" + id);
            return true;
        }

        public async Task<bool> UpdateTestAttemptAsync(TestAttempt obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/TestAttemptCrud/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateTestAttemptAsync(TestAttempt obj)
        {
            await _httpClient.PostAsync(_endpoint + "/TestAttempt/",
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
        }

        public async Task<TestAttempt> GetTestAttemptById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/TestAttemptCrud/" + id);

            var result = JsonConvert.DeserializeObject<TestAttempt>(response);

            return result;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/UserCrud");

            var Users = JsonConvert.DeserializeObject<List<User>>(response);

            return Users;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            await _httpClient.DeleteAsync(_endpoint + "/UserCrud/" + id);
            return true;
        }

        public async Task<bool> UpdateUserAsync(User obj)
        {
            var response = await _httpClient.PutAsync(_endpoint + "/UserCrud/", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            var b = Convert.ToBoolean(response.Content.ReadAsStringAsync());

            return b;
        }

        public async Task CreateUserAsync(User obj)
        {
            await _httpClient.PostAsync(_endpoint + "/UserCrud/",
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
        }

        public async Task<User> GetUserById(Guid id)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + "/UserCrud/" + id);

            var result = JsonConvert.DeserializeObject<User>(response);

            return result;
        }
    }
}