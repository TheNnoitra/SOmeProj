using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCalc.Models
{
    public class RegisterModel
    {
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "Логин")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ты кто такой !?!")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Без пароля - нельзя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Повторите пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Повторение - мать учения")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}