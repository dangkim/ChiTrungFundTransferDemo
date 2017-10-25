using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class UpdateEmployeeCommandValidation : EmployeeValidation<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            ValidateEmployeeId();
            ValidateFirstName();
            ValidateLastName();
        }
    }
}