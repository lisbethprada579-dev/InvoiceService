using InvoiceService.Data;
using InvoiceService.Models;

namespace InvoiceService.Services
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceManager(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateInvoiceAsync(Invoice invoice)
        {
            return await _repository.CreateInvoiceAsync(invoice);
        }

        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            return await _repository.GetInvoiceByIdAsync(id);
        }

        public async Task<List<Invoice>> GetInvoicesByClientAsync(string clientName)
        {
            return await _repository.GetInvoicesByClientAsync(clientName);
        }
    }
}
