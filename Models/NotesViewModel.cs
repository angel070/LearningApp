using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class NotesViewModel
    {
        public IEnumerable<Notes> NotesIndex { get; set; }
        public Notes NotesCreate { get; set; }
    }
}