using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Entidades
{
    public class Fecha
    {
        public int Id { get; set; }
        public DateTime Fecha_retiro { get; set; }
        public int Dias { get; set; }
        public double Retiro { get; set; }
    }
}
