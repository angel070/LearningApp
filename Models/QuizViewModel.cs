using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class QuizViewModel
    {
        public IEnumerable<Quiz> QuizIndex { get; set; }
        public Quiz QuizCreate { get; set; }
    }
}