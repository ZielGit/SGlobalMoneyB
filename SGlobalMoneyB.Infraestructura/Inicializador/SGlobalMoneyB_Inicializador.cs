using SGlobalMoneyB.Infraestructura.ContextoDB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Infraestructura.Inicializador
{
    class SGlobalMoneyB_Inicializador : DropCreateDatabaseAlways<Contexto_SGlobalMoneyB_DB>
    {
        protected override void Seed(Contexto_SGlobalMoneyB_DB context)
        {
            base.Seed(context);
        }
    }
}
