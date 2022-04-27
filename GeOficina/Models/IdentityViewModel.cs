using System.ComponentModel.DataAnnotations;

namespace GeOficina.Models
{
    public class Registro
    {

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage="Campo Obrigatório")]
        [EmailAddress(ErrorMessage ="campo {0} no formático invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage ="O Campo precisa ter entre {1} e {1 Caracteres}")]

        public string Password { get; set; }




        [Compare("Password", ErrorMessage ="As senhas não conferem.")]
       
        public string ConfirmPassword { get; set; }




    }
}


public class Login
{



    [Required(ErrorMessage = "Campo Obrigatório")]   
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(100, ErrorMessage = "O Campo precisa ter entre {1} e {1}")]

    public string Password { get; set; }





}
