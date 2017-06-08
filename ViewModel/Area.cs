using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModel   
{
    public class Area
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar uma área")]
        [StringLength(120)]
        [DisplayName("Nome da área")]
        public string NomeArea { get; set; }

        public List<Cargo> Cargos { get; set; }
    }
}
