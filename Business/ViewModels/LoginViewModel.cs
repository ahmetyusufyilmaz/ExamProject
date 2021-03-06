using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{

    public class LoginViewModel
    {
        //[DisplayName("Email"), Required(ErrorMessage = "{0} field cannot be left blank"), StringLength(25,
        //  ErrorMessage = "{0} max. {1} karakter olmalı.")]

        [Required]
        public string Email { get; set; }
        //[DisplayName("Password"), Required(ErrorMessage = "{0} field cannot be left blank"), DataType(DataType.Password), StringLength(25,
        //  ErrorMessage = "{0} max. {1} karakter olmalı.")] // alanı boş geçilemez


        [Required]
        public string Password { get; set; }
    }
}
