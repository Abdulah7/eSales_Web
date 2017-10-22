using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdajaServis.Util
{
    public class PomocnaKlasa
    {
        
        public static void Handler(EntityException e)
        {
            SqlException greska = (SqlException)e.InnerException;

            switch(greska.Number)
            {
                case 2627:
                   throw throwNowConstraintException(greska);
                default:
                   throw new Exception(greska.Message);
            }
        }

        private static ConstraintException throwNowConstraintException(SqlException greska)
        {
            int poc = greska.Message.IndexOf("'");
            int kraj = greska.Message.IndexOf("'" , poc + 1);
            string newMessage = greska.Message;
            if(poc>0 && kraj>0)
            {
                string temp = greska.Message.Substring(poc + 1, kraj - poc - 1);

                if (temp == "cs_ImeKorisnika")
                    newMessage = "user";
                else
                    if (temp == "cs_Email")
                    
                        newMessage = "email";
            
            }
            return new ConstraintException(newMessage);
        }
    }
}
