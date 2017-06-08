using System.ComponentModel.DataAnnotations;

namespace Negocio
{
    public class Endereco
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Complemento { get; set; }
        
    }
}
