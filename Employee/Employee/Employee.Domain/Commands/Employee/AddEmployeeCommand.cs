using System;
using Employee.Core.Messages;

namespace Employee.Domain.Commands
{
    public class AddEmployeeCommand : Command
    {
        public string Pis { get; private set; }
        public string Description { get; private set; }

        public AddEmployeeCommand(string pis, string description)
        {
            Pis = pis;
            Description = description;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
