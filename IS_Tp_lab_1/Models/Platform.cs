using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "поле не повинно бути порожнім")]
        [Display(Name = "Назва платформи")]
        [StringLength(50, ErrorMessage = "Довжина має не перевищувати 50 символів")]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
