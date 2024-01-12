using System;
using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Models;
using MySql.Data.MySqlClient;
using System.Globalization;
using HelloWorld.Data;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // DataContextDapper dapper = new DataContextDapper();
            DataContextEF entityFramework = new DataContextEF();

            // string sqlCommand = "SELECT NOW();";

            // DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

            // Console.WriteLine(rightNow);

            Computer myComputer = new Computer() 
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            // string sql = @"INSERT INTO Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) 
            //    VALUES ('" + myComputer.Motherboard 
            //            + "'," + (myComputer.HasWifi ? 1 : 0)
            //            + "," + (myComputer.HasLTE ? 1 : 0)
            //            + ",'" + myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss")
            //            + "'," + myComputer.Price.ToString("0.0000", CultureInfo.InvariantCulture)
            //            + ",'" + myComputer.VideoCard
            //    + "')";

            
            // Console.WriteLine(sql);

            // int result = dapper.ExecuteSqlWithRowCount(sql);
            // bool result = dapper.ExecuteSql(sql);
            // Console.WriteLine(result);

            // string sqlSelect = @"SELECT 
            //     Motherboard, 
            //     HasWifi, 
            //     HasLTE, 
            //     ReleaseDate, 
            //     Price, 
            //     VideoCard 
            // FROM Computer";

            
            IEnumerable<Computer>? computersEf = entityFramework.Computers?.ToList<Computer>();

            if(computersEf != null)
            {
                Console.WriteLine("'ComputerId','Motherboard','HasWifi','HasLTE','ReleaseDate'" 
                    + ",'Price','VideoCard'");
                foreach (Computer computer in computersEf)
                {
                    Console.WriteLine(computer.ComputerId 
                        + "'," + computer.Motherboard
                        + "'," + computer.HasWifi
                        + "," + computer.HasLTE
                        + ",'" + computer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss")
                        + "'," + computer.Price.ToString("0.0000", CultureInfo.InvariantCulture)
                        + ",'" + computer.VideoCard);
                }
            }

            // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
            // foreach (Computer computer in computers)
            // {
            //     Console.WriteLine(computer.Motherboard 
            //            + "'," + computer.HasWifi
            //            + "," + computer.HasLTE
            //            + ",'" + computer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss")
            //            + "'," + computer.Price.ToString("0.0000", CultureInfo.InvariantCulture)
            //            + ",'" + computer.VideoCard);
            // }

        }

    }
}