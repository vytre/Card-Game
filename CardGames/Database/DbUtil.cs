using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using CardGames.Entities;

namespace CardGames.Database
{
    public static class DbUtil
    {
        public static void GetDbConnectioString()
        {
            using GamblingDbContext db = new();

            string connection = db.Database.GetConnectionString();

            db.SaveChanges();
            Console.WriteLine(connection);
        }
    }
}
