using System;
using System.Collections.Generic;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class Platform
    {
        public Platform()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
