using InvoiceService.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InvoiceService.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly string _connectionString;

        public InvoiceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // 🔹 CREATE
        public async Task<int> CreateInvoiceAsync(Invoice invoice)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_CreateInvoice", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ClientName", invoice.ClientName);
            command.Parameters.AddWithValue("@Amount", invoice.Amount);
            command.Parameters.AddWithValue("@IssueDate", invoice.IssueDate);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        // 🔹 GET BY ID
        public async Task<Invoice?> GetInvoiceByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_GetInvoiceById", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id", id);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Invoice
                {
                    Id = (int)reader["Id"],
                    ClientName = reader["ClientName"].ToString()!,
                    Amount = (decimal)reader["Amount"],
                    IssueDate = (DateTime)reader["IssueDate"]
                };
            }

            return null;
        }

        // 🔹 GET BY CLIENT
        public async Task<List<Invoice>> GetInvoicesByClientAsync(string clientName)
        {
            var invoices = new List<Invoice>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("sp_GetInvoicesByClient", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@ClientName", clientName);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                invoices.Add(new Invoice
                {
                    Id = (int)reader["Id"],
                    ClientName = reader["ClientName"].ToString()!,
                    Amount = (decimal)reader["Amount"],
                    IssueDate = (DateTime)reader["IssueDate"]
                });
            }

            return invoices;
        }
    }
}
