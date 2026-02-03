using System.ComponentModel.DataAnnotations;

namespace InvoiceService.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [MaxLength(150)]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime IssueDate { get; set; }
    }
}
