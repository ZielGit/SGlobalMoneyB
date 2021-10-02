using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGlobalMoneyB.Core.Entidades
{
    public class Usuario
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
        public DateTime Fecha_Ingreso { get; set; }
        public int? Grupo_Id { get; set; }
        [ForeignKey("Grupo_Id")]
        public virtual Grupo Grupo { get; set; }
        public virtual Referido Referido { get; set; }
    }
}
