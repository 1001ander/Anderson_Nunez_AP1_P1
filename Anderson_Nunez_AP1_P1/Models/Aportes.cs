using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Anderson_Nunez_AP1_P1.Models;

public class Aportes
{
    [Key]
    public int AporteId { get; set; }

    [Required(ErrorMessage = "Campo Fecha obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Campo Nombre obligatorio")]
    [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Campo Monto obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0")]
    public decimal Monto { get; set; }

}
