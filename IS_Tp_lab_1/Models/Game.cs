using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class Game
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "поле не повинно бути порожнім")]
        [Display(Name = "Назва Гри")]
        [StringLength(50, ErrorMessage = "Довжина має не перевищувати 50 символів")]
        public string Name { get; set; }
        [Display(Name = "Жанр")]
        public int GenreId { get; set; }
        [Display(Name = "Платформа")]
        public int PlatformId { get; set; }
        [Display(Name = "Ігрова студія ")]
        public int GameStudioId { get; set; }
        [Display(Name = "Про гру")]
        public string Info { get; set; }

        public virtual GameStudio GameStudio { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
