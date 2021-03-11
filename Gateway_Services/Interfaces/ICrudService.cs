using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway_Services.Models;

namespace Gateway_Services.Interfaces
{
    public interface ICrudService
    {
        Task<IEnumerable<Answer>> GetAllAnswersAsync();
        Task<bool> DeleteAnswerAsync(Guid id);
        Task<bool> UpdateAnswerAsync(Answer obj);
        Task<string> CreateAnswerAsync(Answer obj);
        Task<Answer> GetAnswerById(Guid id);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<bool> DeleteQuestionAsync(Guid id);
        Task<bool> UpdateQuestionAsync(Question obj);
        Task<string> CreateQuestionAsync(Question obj);
        Task<Question> GetQuestionById(Guid id);
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task<bool> DeleteTestAsync(Guid id);
        Task<bool> UpdateTestAsync(Test obj);
        Task<string> CreateTestAsync(Test obj);
        Task<Test> GetTestById(Guid id);
        Task<IEnumerable<TestTheme>> GetAllTestThemesAsync();
        Task<bool> DeleteTestThemeAsync(Guid id);
        Task<bool> UpdateTestThemeAsync(TestTheme obj);
        Task<string> CreateTestThemeAsync(TestTheme obj);
        Task<TestTheme> GetTestThemeById(Guid id);
    }
}