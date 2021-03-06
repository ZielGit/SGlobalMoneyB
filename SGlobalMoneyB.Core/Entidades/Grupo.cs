using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Entidades
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<Usuario> usuarios { get; set; }
        public virtual List<Referido> referidos { get; set; }
    }
}
