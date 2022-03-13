using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Username"),
            Required(ErrorMessage = "{0} field cannot be left blank!"),
            StringLength(25, ErrorMessage = "{0} must be {1} characters.")]
        public string Username { get; set; }
        [DisplayName("Email"),
            Required(ErrorMessage = "{0} field cannot be left blank!"), //boş bırakılamaz
            StringLength(70, ErrorMessage = "{0} must be {1} characters."),// max karakter {1} olmalı
            EmailAddress(ErrorMessage = "Please enter a vaild e-mail address for the {0} field")] //geçerli mail adresi girin
        public string Email { get; set; }

        [DisplayName("Password"),
            Required(ErrorMessage = "{0} field cannot be left blank!"), DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} must be {1} characters.")]
        public string Password { get; set; }
        [DisplayName("Password again"),
            Required(ErrorMessage = "{0} field cannot be left blank!"), DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} must be {1} characters."),
            Compare("Password", ErrorMessage = "{0} and {1} don't match")]
        public string RePassword { get; set; }
    }
}
