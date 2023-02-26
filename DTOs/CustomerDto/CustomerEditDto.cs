
namespace BackEnd.DTOs.CustomerDto
{
    public class CustomerEditDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }
    }
}