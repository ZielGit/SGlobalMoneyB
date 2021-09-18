using SGlobalMoneyB.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Infraestructura.ContextoDB
{
    public class Contexto_SGlobalMoneyB_DB : DbContext
    {
        public Contexto_SGlobalMoneyB_DB() : base("name=Contexto_SGlobalMoneyB_DB_Con") { }
        // llamando las entidades para crear las tablas
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Referido> referidos { get; set; }
        public DbSet<Grupo> grupos { get; set; }
    }
}
