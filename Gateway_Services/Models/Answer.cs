using System;

namespace Gateway_Services.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Guid? QuestionId { get; set; }
    }
}