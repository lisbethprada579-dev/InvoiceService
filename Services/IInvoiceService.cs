using InvoiceService.Models;

namespace InvoiceService.Services
{
    public interface IInvoiceService
    {
        Task<int> CreateInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetInvoiceByIdAsync(int id);
        Task<List<Invoice>> GetInvoicesByClientAsync(string clientName);
    }
}
