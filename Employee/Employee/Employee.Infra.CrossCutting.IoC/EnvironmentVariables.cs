using System;

namespace Employee.Infra.CrossCutting.IoC
{
    public class EnvironmentVariables
    {
        public EnvironmentVariables()
        {
            CreateConnectionStrings();
            CreateS3();
            CreateSQS();
        }

        public string OracleConnectionString { get; private set; }
        public string SqlServerConnectionString { get; private set; }
        public string S3Bucket { get; private set; }
        public string SQSQueue { get; private set; }

        private void CreateConnectionStrings()
        {
            OracleConnectionString = "User Id=pontop;Password=Ved0crT;Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.30.0.137)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SID = QADB ) ) );";
            SqlServerConnectionString = "Server=tcp:sqlserver-qa.certponto.com.br,1433;Data Source=sqlserver-qa.certponto.com.br;Initial Catalog=CDGServer;Persist Security Info=False;User ID=cdgv2_master;Password=eA8w9TiDsJDl2X8q;MultipleActiveResultSets=True;";

            if (Environment.GetEnvironmentVariable("OracleConnectionString") != null)
                OracleConnectionString = Environment.GetEnvironmentVariable("OracleConnectionString");

            if (Environment.GetEnvironmentVariable("SqlServerConnectionString") != null)
                SqlServerConnectionString = Environment.GetEnvironmentVariable("SqlServerConnectionString");
        }

        private void CreateS3()
        {
            S3Bucket = "bucket-name";

            if (Environment.GetEnvironmentVariable("S3Bucket") != null)
                S3Bucket = Environment.GetEnvironmentVariable("S3Bucket");
        }

        private void CreateSQS()
        {
            SQSQueue = "";

            if (Environment.GetEnvironmentVariable("SQSQueue") != null)
                SQSQueue = Environment.GetEnvironmentVariable("SQSQueue");
        }
    }
}
