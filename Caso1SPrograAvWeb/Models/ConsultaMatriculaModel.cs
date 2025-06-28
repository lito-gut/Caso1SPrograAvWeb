using System;

namespace Caso1SPrograAvWeb.Models
{
    public class ConsultaMatriculaModel
    {
        public string? NombreEstudiante { get; set; }
        public string? DescripcionTipoCurso { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}