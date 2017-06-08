using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class Cargo
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar um cargo")]
        [DisplayName("Nome do Cargo")]
        public string NomeCargo { get; set; }

        [Required]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        
    }
}
