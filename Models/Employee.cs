using System.ComponentModel.DataAnnotations;

namespace Minimal.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int Code { get; set; } = 0;
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set; }
        public DateTime BirthDay { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModificatedAt { get; set; } = DateTime.Now;

        public int? AddressId { get; set; }
        [JsonIgnore]
        public EmployeeAddress Address { get; set; }

    }
}