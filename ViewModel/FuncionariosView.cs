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

        public Guid PesquisaAreaId { get; set; }

        public Guid PesquisaCargoId { get; set; }
    }
}
