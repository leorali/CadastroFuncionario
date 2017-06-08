using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class Endereco
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Favor informar um logradouro")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Favor informar um CEP")]
        [DisplayName("CEP")]
        [MaxLength(9)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Favo informar um complemento para o endereço")]
        [DisplayName("Complemento")]
        public string Complemento { get; set; }
        
    }
}
