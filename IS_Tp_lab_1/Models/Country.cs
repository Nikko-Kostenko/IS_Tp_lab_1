using System;
using System.Collections.Generic;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class Country
    {
        public Country()
        {
            GameStudios = new HashSet<GameStudio>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameStudio> GameStudios { get; set; }
    }
}
