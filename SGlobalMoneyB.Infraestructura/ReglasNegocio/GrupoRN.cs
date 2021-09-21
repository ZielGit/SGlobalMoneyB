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
    public class GrupoRN : IGrupo
    {
        Contexto_SGlobalMoneyB_DB contexto;

        public void Agregar(Grupo grupo)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            contexto.grupos.Add(grupo);
            contexto.SaveChanges();
        }

        public Grupo Buscar(int Id)
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            var resultado = contexto.grupos.Find(Id);
            return resultado;
        }

        public IEnumerable<Grupo> ListarGrupo()
        {
            contexto = new Contexto_SGlobalMoneyB_DB();
            return contexto.grupos.ToList();
        }

        public void Modificar(Grupo grupo)
        {
            contexto.Entry(grupo).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
