using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class ProgrammeViewModel
    {
        public IEnumerable<Programme> ProgrammeIndex { get; set; }
        public Programme ProgrammeCreate { get; set; }
    }
}