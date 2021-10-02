using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Entidades.ViewModel;
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

        public void AgregarUsuario(Usuario usuario)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            var user = new usuario();
            usuario.Nombre = user.Nombre;
            usuario.Apellido = user.Apellido;
            usuario.DNI = user.DNI;
            usuario.Edad = user.Edad;
            usuario.Genero = user.Genero;
            usuario.Celular = user.Celular;
            usuario.Direccion = user.Direccion;
            usuario.Monto_Inicial = user.Monto_Inicial;
            usuario.Fecha_Ingreso = user.Fecha_Ingreso;
            usuario.Hora = user.Hora;
            usuario.Grupo_Id = user.Grupo_Id;
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

        public IEnumerable<usuario> Listar()
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            return contexto.usuarios.Select(u => new usuario() { 
                Id = u.Id, 
                Nombre = u.Nombre, 
                Apellido = u.Apellido,
                DNI = u.DNI,
                Edad = u.Edad,
                Genero = u.Genero,
                Celular = u.Celular,
                Direccion = u.Direccion,
                Monto_Inicial = u.Monto_Inicial,
                Fecha_Ingreso = u.Fecha_Ingreso,
                grupo = u.Grupo.Nombre,
                referido = u.Referido.Nombre
            }).ToList();
        }

        public void Modificar(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Eliminar(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}
