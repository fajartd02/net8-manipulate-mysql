using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        private string _connectionString = "Server=localhost;Port=3306;Database=DotNetCourseDatabase;Uid=root;Pwd=devRoot123;";
        
        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }
         
         public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return (dbConnection.Execute(sql) > 0);
        }

        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            return dbConnection.Execute(sql);
        }

    }
}