
using InvoiceService.Models;

namespace InvoiceService.Data
{
    public interface IInvoiceRepository
    {
        Task<int> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<List<Invoice>> GetInvoicesByClientAsync(string clientName);
    }
}
