using EnvGraphique.Evaluation2.ATM.Domain.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain
{
    public class ATMDbContext
    {
        private static ATMEntities instance = null;
        private static readonly object threadLock = new object();

        private ATMDbContext()
        {
        }

        public static ATMEntities Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new ATMEntities();
                    }

                    return instance;

                }
            }
        }

        public async static Task<bool> IsConnectionWorking()
        {
            if (instance != null)
            {
                try
                {
                    await instance.Database.Connection.OpenAsync();
                    instance.Database.Connection.Close();

                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }

            return false;
        }

        //public async static Task<DateTime> GetDbDateTime()
        //{
        //    DateTime dateTime = new DateTime();

        //    if(await IsConnectionWorking())
        //    {
        //        var command = Instance.Database.Connection.CreateCommand();
        //        command.CommandText = "select SYSUTCDATETIME()";
        //        dateTime = (DateTime)command.ExecuteScalar();
        //    }

        //    return dateTime;
        //}
    }
}
