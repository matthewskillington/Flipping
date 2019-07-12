using System;
using System.Collections.Generic;
using System.Text;

namespace Flipping.Models
{
    public class RunescapeItem
    {
        public string Icon { get; set; }
        public string Icon_large { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class IdMatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
