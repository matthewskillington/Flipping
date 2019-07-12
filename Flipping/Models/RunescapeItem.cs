using System;
using System.Collections.Generic;
using System.Text;

namespace Flipping.Models
{
    public class RunescapeItem
    {
        public RunescapeItem(string icon,
                             string icon_large,
                             int id,
                             string name,
                             string description,
                             int price)
        {
            Icon = icon;
            Icon_large = icon_large;
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public string Icon { get; set; }
        public string Icon_large { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class IdMatch
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
