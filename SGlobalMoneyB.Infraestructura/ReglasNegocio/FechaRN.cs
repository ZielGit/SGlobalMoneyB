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
    public class FechaRN : IFecha
    {
        Contexto_SGlobalMoneyB_DB contexto;
        public void Agregar(Fecha fecha)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            contexto.fechas.Add(fecha);
            contexto.SaveChanges();
        }
    }
}
