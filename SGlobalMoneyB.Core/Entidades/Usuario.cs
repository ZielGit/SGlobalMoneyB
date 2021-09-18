using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGlobalMoneyB.Core.Entidades
{
    public class Usuario
    {
        int Id { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        int DNI { get; set; }
        int Edad { get; set; }
        string Genero { get; set; }
        int Celular { get; set; }
        string Referido { get; set; }
        string Dirección { get; set; }
        int Monto_Inicial { get; set; }
        string Grupo { get; set; }
        DateTime Fecha_Ingreso { get; set; }
    }
}
