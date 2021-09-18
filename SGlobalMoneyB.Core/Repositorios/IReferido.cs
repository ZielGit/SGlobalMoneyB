using SGlobalMoneyB.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Repositorios
{
    public interface IReferido
    {
        void Agregar(Referido referido);
        void Modificar(Referido referido);
        IEnumerable<Referido> ListarReferido();
        Referido Buscar(int Id);
    }
}
