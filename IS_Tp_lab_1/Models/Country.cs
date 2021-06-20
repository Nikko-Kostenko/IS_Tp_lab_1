using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "поле не повинно бути порожнім")]
        [Display(Name = "Назва Країни")]
        [StringLength(50, ErrorMessage = "Довжина має не перевищувати 50 символів")]
        public string Name { get; set; }

        public virtual ICollection<GameStudio> GameStudios { get; set; }
    }
}
