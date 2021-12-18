using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Examen_3.Models
{
    public class Empleado
{
       
            [PrimaryKey, AutoIncrement]
            public int Id_empleado { get; set; }
            [MaxLength(255)]
            public string Nombre { get; set; }
            [MaxLength(255)]
            public string Apellido { get; set; }
            [MaxLength(255)]
            public string Edad { get; set; }
            [MaxLength(255)]
            public string Direccion { get; set; }
            [MaxLength(255)]
            public string Puesto { get; set; }


        ////public byte[] Photo_recibo { get; set; }


    }
}
