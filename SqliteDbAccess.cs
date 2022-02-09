using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace TodoList
{
    public class SqliteDbAccess
    {

        public static List<Todo> LoadTodos()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<Todo> output = cnn.Query<Todo>("select * from Todos", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveTodo(Todo todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                _ = cnn.Execute("insert into Todos (Description) values (@Description)", todo);
            }
        }

        public static void DeleteTodo(Todo todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                _ = cnn.Execute("delete from Todos where Id = @Id", todo);
            }
        }

        public static void UpdateTodo(Todo todo)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                _ = cnn.Execute("update Todos set Description = @Description, Status = @Status where Id = @Id", todo);
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
