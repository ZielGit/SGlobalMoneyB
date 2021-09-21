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
    public class ReferidoRN : IReferido
    {
        Contexto_SGlobalMoneyB_DB contexto;

        public void Agregar(Referido referido)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            contexto.referidos.Add(referido);
            contexto.SaveChanges();
        }

        public Referido Buscar(int Id)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            var resultado = contexto.referidos.Find(Id);
            return resultado;
        }

        public IEnumerable<Referido> ListarReferido()
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            return contexto.referidos.ToList();
        }

        public void Modificar(Referido referido)
        {
            contexto.Entry(referido).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
