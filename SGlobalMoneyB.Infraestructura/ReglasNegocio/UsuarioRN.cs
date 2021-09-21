using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Repositorios;
using SGlobalMoneyB.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Infraestructura.ReglasNegocio
{
    public class UsuarioRN : IUsuario
    {
        Contexto_SGlobalMoneyB_DB contexto;

        public void Agregar(Usuario usuario)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            contexto.usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public Usuario Buscar(int Id)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            var resultado = contexto.usuarios.Find(Id);
            return resultado;
        }

        public IEnumerable<Usuario> ListarUsuario()
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            return contexto.usuarios.ToList();
        }

        public void Modificar(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
