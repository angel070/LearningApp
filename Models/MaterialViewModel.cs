using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Models
{
    public class MaterialViewModel
    {
        public IEnumerable<Material> MaterialIndex { get; set; }
        public Material MaterialCreate { get; set; }
    }
}