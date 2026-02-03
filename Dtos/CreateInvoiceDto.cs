using System.ComponentModel.DataAnnotations;

namespace InvoiceService.DTOs
{
    public class CreateInvoiceDto
    {
        [Required]
        [StringLength(150)]
        public string ClientName { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
