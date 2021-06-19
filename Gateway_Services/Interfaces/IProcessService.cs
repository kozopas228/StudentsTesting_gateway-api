using Gateway_Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway_Services.Interfaces
{
    public interface IProcessService
    {
        Task<CheckResultModel> CheckAnswer(CheckAnswerViewModel viewModel);
        Task<ICollection<Question>> MixQuestions(Guid testId);
    }
}