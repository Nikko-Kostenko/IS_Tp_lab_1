using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IS_Tp_lab_1
{
    public partial class GameStudio
    {
        public GameStudio()
        {
            Games = new HashSet<Game>();
        }
        [Display(Name = "Назва Студії")]
        public int Id { get; set; }
        [Required(ErrorMessage = "поле не повинно бути порожнім")]
        [Display(Name = "Назва Студії")]
        [StringLength(50, ErrorMessage = "Довжина має не перевищувати 50 символів")]
        public string Name { get; set; }
        [Display(Name = "Інформація")]
        public string Info { get; set; }
        
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
