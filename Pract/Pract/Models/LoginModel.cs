using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pract.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Не указан логин")]
        [Display(Name="Логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}