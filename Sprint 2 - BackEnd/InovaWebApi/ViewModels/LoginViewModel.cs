using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuário")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
