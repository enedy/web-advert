using Employee.Domain.Entities.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Employee.Core.DomainObjects;

namespace Employee.Domain.Entities
{
    [Table("TAV_TRABAL")]
    public class Employee : Entity, IAggregateRoot
    {
        protected Employee()
        {
        }

        public Employee(string pis, string description)
        {
            PIS = pis;
            Description = description;

            Validate(this, new EmployeeValidator());
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRB_IDENTI")]
        public long Id { get; private set; }
        [Column("TRB_PIS")]
        public string PIS { get; private set; }
        [Column("TRB_DESCRI")]
        public string Description { get; private set; }

    }
}
