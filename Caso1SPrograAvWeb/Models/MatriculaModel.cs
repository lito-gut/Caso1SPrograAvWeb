using System;
using System.ComponentModel.DataAnnotations;

namespace Caso1SPrograAvWeb.Models
{
    public class MatriculaModel
    {
        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
        public string? NombreEstudiante { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser un número positivo.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El tipo de curso es obligatorio.")]
        public int TipoCurso { get; set; }

        // Constructor sin lógica adicional (opcional en .NET Core si se usa validación por atributos)
        public MatriculaModel() { }

        public MatriculaModel(string nombreEstudiante, decimal monto, int tipoCurso)
        {
            if (string.IsNullOrWhiteSpace(nombreEstudiante))
                throw new ArgumentException("El nombre del estudiante es obligatorio.");

            if (monto <= 0)
                throw new ArgumentException("El monto debe ser un número positivo.");

            if (tipoCurso <= 0)
                throw new ArgumentException("El tipo de curso es obligatorio.");

            NombreEstudiante = nombreEstudiante;
            Fecha = DateTime.Now;
            Monto = monto;
            TipoCurso = tipoCurso;
        }
    }
}