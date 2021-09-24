using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Repositorios;
using SGlobalMoneyB.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Infraestructura.ReglasNegocio
{
    public class Reportes : IReporte
    {
        Contexto_SGlobalMoneyB_DB contexto;
        public IQueryable<oReporteUsuario> oReporteUsuarios()
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            return contexto.usuarios.Select(u => new oReporteUsuario() 
            { 
                Id = u.Id, 
                Nombre = u.Nombre, 
                Apellido = u.Apellido,
                DNI = u.DNI,
                Edad = u.Edad,
                Genero = u.Genero,
                Celular = u.Celular,
                Direccion = u.Direccion,
                Monto_Inicial = u.Monto_Inicial,
                Fecha_Ingreso = u.Fecha_Ingreso
            }).AsQueryable<oReporteUsuario>();
        }
    }
}
