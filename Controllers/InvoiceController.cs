using InvoiceService.Data;
using InvoiceService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceService.Controllers
{
    [ApiController]
    [Route("invoice")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceController(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        // POST /invoice
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _repository.CreateInvoiceAsync(invoice);

            return CreatedAtAction(nameof(GetInvoiceById), new { id }, new { id });
        }

        // GET /invoice/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var invoice = await _repository.GetInvoiceByIdAsync(id);

            if (invoice == null)
                return NotFound(new { message = "Factura no encontrada" });

            return Ok(invoice);
        }

        // GET /invoice/search?client=Juan
        [HttpGet("search")]
        public async Task<IActionResult> GetByClient([FromQuery] string client)
        {
            if (string.IsNullOrWhiteSpace(client))
                return BadRequest(new { message = "El parámetro client es obligatorio" });

            var invoices = await _repository.GetInvoicesByClientAsync(client);

            return Ok(invoices);
        }
    }
}
