using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class Funcionario
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do funcionário")]
        [StringLength(120)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar o CPF")]
        [MaxLength(14)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Favor escolher o sexo")]
        public string Sexo { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; } 
           
        [Required]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public int? GestorId { get; set; }

        public Funcionario Gestor { get; set; }
        
        [Required(ErrorMessage = "Favor informar a data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public List<Beneficio> Beneficios { get; set; }
    }
}
