using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio
{
    public class Funcionario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; } 
           
        [Required]
        public int CargoId { get; set; }
        public virtual Cargo Cargo { get; set; }

        [ForeignKey("Gestor")]
        public int? GestorId { get; set; }

        public virtual Funcionario Gestor { get; set; }
        
        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Beneficio> Beneficios { get; set; }
    }
}
