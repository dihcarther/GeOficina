using System.ComponentModel.DataAnnotations;

namespace GeOficina.Models
{
    public class AgendamentoModel
    {
        [Key]
        public int Id { get; set; }
        public int UndTrabalho { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public int CnpjOficina { get; set; }
        public string NomeCliente { get; set; }
    }
}
