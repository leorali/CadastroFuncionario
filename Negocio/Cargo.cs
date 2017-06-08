using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cargo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeCargo { get; set; }

        [Required]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }

    }
}
