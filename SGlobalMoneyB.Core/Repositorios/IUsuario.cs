using SGlobalMoneyB.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Repositorios
{
    public interface IUsuario
    {
        void Agregar(Usuario usuario);
        void Modificar(Usuario usuario);
        IEnumerable<Usuario> ListarUsuario();
        Usuario Buscar(int Id);
    }
}
