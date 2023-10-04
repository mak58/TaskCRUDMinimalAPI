using System.ComponentModel.DataAnnotations;

namespace Minimal.Models
{
    public class EmployeeAddress
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Street is Required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Residence Number is Required")]
        public string AddressNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        
        public EState State { get; set; } = EState.RioGrandeDoSul;

        public ECountry Country { get; set; } = ECountry.Brasil;

    }
}