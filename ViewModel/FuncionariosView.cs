using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FuncionariosView
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public int? PesquisaAreaId { get; set; }

        public int? PesquisaCargoId { get; set; }
    }
}
