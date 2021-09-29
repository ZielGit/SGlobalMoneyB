using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Entidades.ViewModel;
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
        void Eliminar(Usuario usuario);
        IEnumerable<Usuario> ListarUsuario();
        IEnumerable<usuario> Listar();
        Usuario Buscar(int Id);
    }
}
