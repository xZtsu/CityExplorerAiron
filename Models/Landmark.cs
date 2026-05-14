using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityExplorerAiron.Models
{
    public class Landmark
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryEmoji { get; set; } 
    }
}
