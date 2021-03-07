using System;
using System.Collections.Generic;

namespace Gateway_Services.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public ICollection<Guid?> AnswersIds { get; set; }
        public Guid? TestId { get; set; }
    }
}