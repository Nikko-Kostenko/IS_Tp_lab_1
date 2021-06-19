using System;
using System.Collections.Generic;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int PlatformId { get; set; }
        public int GameStudioId { get; set; }
        public string Info { get; set; }

        public virtual GameStudio GameStudio { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
