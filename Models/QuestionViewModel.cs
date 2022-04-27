using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class QuestionViewModel
    {
        /*public IEnumerable<Question> QuestionIndex { get; set; }
        public Question QuestionCreate { get; set; }*/
        public string Quest { get; set; }
        public string Ans { get; set; }
        public string Reason { get; set; }
        public string Opt { get; set; }
        public int TopicId { get; set; }

    }
}