using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Models
{
    public class QuestionOptionsViewModel
    {
        public string Question{get; set;}
        public string Reason{get; set;}
        public List<string> ListOfOptions { get; set; }
        public int TopicId{get; set;}
        public string AnswerText{get; set;}
       

    }
}