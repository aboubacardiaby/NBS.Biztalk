
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBS.Biztalk.Logging
{
    [Serializable]
    public class Log
    {
        public static void Loginfo()
        {

        }

        private void logsInOracle()
        {

        }

        public static void LogInSql (string applicationId, string severity, string Machiname,string appdomamin, string processId,
                                    string processname,string win32Thread, string message)
        {
            var connectionstring = SSOSettingsFileManager.SSOSettingsFileReader.ReadString("NBS.Biztalk", "ConnectionString");

           
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("WriteLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ApplicationId", SqlDbType.Int).Value = applicationId;
                    cmd.Parameters.Add("@severity", SqlDbType.VarChar).Value = severity;
                    cmd.Parameters.Add("@MachineName", SqlDbType.VarChar).Value = Machiname;
                    cmd.Parameters.Add("@AppDomainName", SqlDbType.VarChar).Value = appdomamin;
                    cmd.Parameters.Add("@ProcessID", SqlDbType.VarChar).Value = processname;
                    cmd.Parameters.Add("@ProcessName", SqlDbType.VarChar).Value = processname;
                    cmd.Parameters.Add("@Win32ThreadId", SqlDbType.VarChar).Value = win32Thread;
                    cmd.Parameters.Add("@Message", SqlDbType.VarChar).Value = message;
                    cmd.Parameters.Add("@LogId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
