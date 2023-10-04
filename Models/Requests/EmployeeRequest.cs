namespace Minimal.Models.Requests
{
    public record EmployeeRequest(string FirstName,
                                  string LastName,
                                  string Email,
                                  EmployeeAddress Address);
}