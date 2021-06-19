using System;
using System.Collections.Generic;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class GameStudio
    {
        public GameStudio()
        {
            Games = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
