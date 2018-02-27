using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class ProfileModel
    {
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "День рождения")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}