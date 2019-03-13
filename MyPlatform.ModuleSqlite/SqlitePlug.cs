using MyPlatform.Standard;
using System.Data.SQLite;

namespace MyPlatform.ModuleSqlite
{
    public class SqlitePlug : IPlugItem
    {
        public SqlitePlug()
        {
        }

        public string Name { get { return "nuget sqlite 第三方组件引用非.net dll"; } }

        public void Execute()
        {
            var sqlbuilder = new SQLiteConnectionStringBuilder();
         
            sqlbuilder.DataSource = "memory";
            SQLiteConnection connection = new SQLiteConnection(sqlbuilder.ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "select datetime('now')";
            var result = cmd.ExecuteScalar();
            System.Console.WriteLine("sqlite Command:{0} {1}", cmd.CommandText, result);
        }
    }
}