using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Entidades.ViewModel
{
    public class usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public int Celular { get; set; }
        public string Referido { get; set; }
        public string Direccion { get; set; }
        public int Monto_Inicial { get; set; }
        public string Grupo { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
    }
}
