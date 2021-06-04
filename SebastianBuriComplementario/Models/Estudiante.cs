using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SebastianBuriComplementario.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]

        [MaxLength(255)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Nombre { get; set; }

        [MaxLength(255)]
        public string Usuario { get; set; }

        [MaxLength(255)]
        public string Contrasena { get; set; }



    }
}
