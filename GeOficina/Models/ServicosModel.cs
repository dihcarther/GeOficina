using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace GeOficina.Models
{
    
    [Table("Servicos")]
    
   
    public class ServicosModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UndTrabalho { get; set; }

    }

     
}
