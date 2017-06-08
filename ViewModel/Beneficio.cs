using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class Beneficio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar um tipo de beneficio")]
        [DisplayName("Tipo de Beneficio")]
        public string TipoDeBeneficio { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
