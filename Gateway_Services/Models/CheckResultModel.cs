using System.Collections.Generic;

namespace Gateway_Services.Models
{
    public class CheckResultModel
    {
        public bool Correct { get; set; }
        public ICollection<Answer> CorrectAnswers { get; set; }
    }
}