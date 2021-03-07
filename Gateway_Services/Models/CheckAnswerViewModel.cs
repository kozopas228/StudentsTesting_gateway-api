using System;

namespace Gateway_Services.Models
{
    public class CheckAnswerViewModel
    {
        public Guid testId { get; set; }
        public Guid questionId { get; set; }
        public Guid[] answersId { get; set; }
    }
}
