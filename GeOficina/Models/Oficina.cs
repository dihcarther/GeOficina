using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeOficina.Models
{

    [Table("Oficina")]
    public class Oficina
    {
              
        [Key]
        public int Id { get; set; }
        
        [Required]
         [MaxLength(255)]
         [MinLength(3)]
         [Display(Name ="Nome")]
        public string Nome { get; set; }

   

        public int Cnpj { get; set; }


        public int CargaDeTrabalho { get; set; }

        public string Endereco { get; set; }

        
        [MaxLength(30)]
        [MinLength(5)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

    }
}
