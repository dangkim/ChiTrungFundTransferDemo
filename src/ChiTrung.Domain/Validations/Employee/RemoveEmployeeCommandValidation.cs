using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class RemoveEmployeeCommandValidation : EmployeeValidation<RemoveEmployeeCommand>
    {
        public RemoveEmployeeCommandValidation()
        {
            ValidateEmployeeId();
            ValidateFirstName();
            ValidateLastName();
        }
    }
}