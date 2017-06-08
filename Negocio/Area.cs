using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Area
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string NomeArea { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
