using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway_Services.Models;

namespace Gateway_Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<string> Login(string login, string password);
        Task<bool> Register(string login, string password, string firstName, string lastName);
        Task<Guid> GetUserIdByLogin(string login);
        Task<ICollection<TestAttempt>> GetUserAttempts(Guid id);
        Task<ICollection<TestAttempt>> ChangeUserRole(Guid id, string role);
        Task AddAttemptToUser(Guid id, Guid testId);
        Task<bool> ChangeUserLogin(Guid userId, string newLogin);
        Task<bool> ChangeUserPassword(Guid userId, string newLogin);
        Task<bool> ChangeUserFirstName(Guid userId, string newFirstName);
        Task<bool> ChangeUserLastName(Guid userId, string newLastName);
        Task<bool> SaveAttemptToUser(Guid userId, TestAttempt attempt);
        Task<IEnumerable<TestAttempt>> GetAllTestAttemptsAsync();
        Task<bool> DeleteTestAttemptAsync(Guid id);
        Task<bool> UpdateTestAttemptAsync(TestAttempt obj);
        Task CreateTestAttemptAsync(TestAttempt obj);
        Task<TestAttempt> GetTestAttemptById(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(Guid id);
        Task<bool> UpdateUserAsync(User obj);
        Task CreateUserAsync(User obj);
        Task<User> GetUserById(Guid id);
    }
}