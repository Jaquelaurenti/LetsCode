using StarWarsResistence.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsResistence.Utils
{
    public static class Utils
    {
        public static string EncryptConnectionString(string connectionString)
        {
            Byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(connectionString);
            string encryptedConnection = Convert.ToBase64String(b);
            return encryptedConnection;

        }
    }
}
