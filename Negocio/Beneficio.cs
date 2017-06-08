using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Beneficio
    {
        public int Id { get; set; }

        [Required]
        public string TipoDeBeneficio { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
