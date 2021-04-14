using Employee.Domain.Entities;
using Employee.Domain.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Employee.Core.Commands;
using Employee.Core.Communication.Mediator;

namespace Employee.Domain.Commands
{
    public class AddEmployeeCommandHandler : CommandHandler, IRequestHandler<AddEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeCommandHandler(IMediatorHandler mediatorHandler,
            IEmployeeRepository employeeRepository) : base(mediatorHandler)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = new Employee(command.Pis, command.Description);

            if (!await ValidateEntity(employee))
                return false;

            return true;
        }
    }
}
