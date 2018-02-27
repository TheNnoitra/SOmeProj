using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class NewDocModel
    {
        [Display(Name = "Имя документа")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string DocName { get; set; }

        [Display(Name = "Текст Докумета")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Документ не должен быть пустой!")]
        public string DocText { get; set; }
    }
}