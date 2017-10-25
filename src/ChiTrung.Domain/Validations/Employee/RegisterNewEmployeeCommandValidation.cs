using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class RegisterNewEmployeeCommandValidation : EmployeeValidation<RegisterNewEmployeeCommand>
    {
        public RegisterNewEmployeeCommandValidation()
        {
            ValidateFirstName();
            ValidateLastName();
        }
    }
}