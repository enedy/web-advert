using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Employee.Function.Extensions;
using System;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Commands;
using Employee.Infra.CrossCutting.IoC;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Employee.Function
{
    public class Functions : FunctionBase
    {
        public Functions() { }

        public async Task<string> Teste(SQSEvent sqsEvent, ILambdaContext context)
        {
            try
            {
                // CONTEM AS VARIÁVEIS DE AMBIENTE
                var env = new EnvironmentVariables();

                var command = new AddEmployeeCommand("123456789102", "Description");
                await this._mediatorHandler.SendCommand(command);

                // VERIFICA SE TUDO OCORREU BEM COM A VALIDAÇÃO
                this.CheckNotification();

                return "OK";
            }
            catch (Exception ex)
            {
                context.Logger.LogLine($"Erro Message: {ex.Message}");
                context.Logger.LogLine($"Inner Message: {ex.InnerException?.Message}");
                throw ex;
            }
        }

        private void CheckNotification()
        {
            if (this.CheckOperation() == false)
            {
                var notifiations = new StringBuilder();
                var breakLine = "\r\n";

                foreach (var notification in this.GetNotifications())
                    notifiations.Append($"{ notification }").Append(breakLine);

                throw new Exception(notifiations.ToString());
            }
        }
    }

}
