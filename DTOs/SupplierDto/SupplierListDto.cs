
namespace BackEnd.DTOs.SupplierDto
{
    public class SupplierListDto
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }
    }
}