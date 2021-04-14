using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Employee.Core.DomainObjects;

namespace Employee.Domain.Entities
{
    [Table("TAV_SINCRO")]
    public class Synchronization : Entity, IAggregateRoot
    {
        protected Synchronization() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SIC_IDENTI")]
        public long Id { get; private set; }
        [Column("SIC_EMP_IDENTI")]
        public long CompanyId { get; private set; }
        [Column("SIC_ARQUIV")]
        public string PathFile { get; private set; }
        [Column("SIC_ERRO")]
        public string Error { get; private set; }
        [Column("SIC_STATUS")]
        public string Status { get; private set; }
        [Column("SIC_DTAINI")]
        public DateTime? StartDate { get; set; }
        [Column("SIC_DTAFIM")]
        public DateTime? EndDate { get; private set; }
        [Column("SIC_BCOGER")]
        public char? ProcessStatus { get; private set; }
        [Column("SIC_GERERR")]
        public string GeneratedError { get; private set; }
        [Column("SIC_TOTSIN")]
        public int? TotalSynchronized { get; private set; }

        public void StartProcessCDG()
        {
            Status = "Em processamento";
            //StartDate = Util.GetDateTimeIgnoreDayLight();
        }

        public void ErrorImportProcessCDG(string error)
        {
            Error = error;
            ProcessStatus = 'E';
        }

        public void EndImportProcessCDG(int totalSynchronized)
        {
            Status = "Processado";
            TotalSynchronized = TotalSynchronized ?? 0 + totalSynchronized;
            //EndDate = Util.GetDateTimeIgnoreDayLight();
            ProcessStatus = string.IsNullOrEmpty(Error) ? 'F' : 'E';
        }

        public void StartProcessOracle()
        {
            ProcessStatus = 'A';
        }

        public void ErrorImportProcessOracle(string error)
        {
            Error = error;
            ProcessStatus = 'E';
        }

        public void EndImportProcessOracle()
        {
            ProcessStatus = 'V';
        }

        public string GetValueProcessStatus()
        {
            switch (ProcessStatus)
            {
                case 'F':
                    return "Fila de espera";
                case 'A':
                    return "Executando";
                case 'E':
                    return GeneratedError;
                case 'V':
                    return "Sucesso";
                default:
                    return null;
            }
        }
    }
}
