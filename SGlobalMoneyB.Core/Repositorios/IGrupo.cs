using SGlobalMoneyB.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Repositorios
{
    public interface IGrupo
    {
        void Agregar(Grupo grupo);
        void Modificar(Grupo grupo);
        IEnumerable<Grupo> ListarGrupo();
        Grupo Buscar(int Id);
    }
}
