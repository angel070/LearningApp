using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class TopicViewModel
    {
        public IEnumerable<Topic> TopicIndex { get; set; }
        public Topic TopicCreate { get; set; }
    }
}