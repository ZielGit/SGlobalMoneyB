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
        public string DNI { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }
        public int Monto_Inicial { get; set; }
        public string referido { get; set; }
        public string grupo { get; set; }
        public string Hora { get; set; }
        // se agrego el siguiente campo
        public int Grupo_Id { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
    }
}
