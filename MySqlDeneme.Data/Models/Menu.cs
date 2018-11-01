using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlDeneme.Data.Models
{
    public class Menu
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? TopMenuId { get; set; }
    }
}
