using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    public class Connection
    {
        /// <summary>
        /// Field to store the connection string.
        /// Because of the readonly keyword, you can't set the value outside the constructor
        /// </summary>
        /// <example>
        /// <c>Data Source=MyServer;Initial Catalog=MyDb;Integrated Security=True;</c>
        /// </example>
        private readonly string _ConnectionString;

        /// <summary>
        /// Connection constructor which initialize the _ConnectionString field from our parameter 
        /// </summary>
        /// <example>
        /// <c>Connection c = new Connection ("Data Source=MyServer;Initial Catalog=MyDb;Integrated Security=True;");</c>
        /// </example>
        public Connection(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        /// <summary>
        /// fonction qui 1./ récupère les données renvoyées par la BD suit l'exécution d'une requête.
        ///              2./ recoit 2 paramètres:    
        /// a)The executed query, located in the Query property of the Command object.
        /// b)l'address of the function callback (ou delegué)to execute. 
        ///        Cette callback mappe the column data (de la DB) to the properties of a C# object.
        /// </summary>
        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<SqlDataReader, TResult> selector)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<TResult> items = new List<TResult>();
                        while (dataReader.Read())
                        {
                            items.Add(selector(dataReader));
                        }

                        return items;
                    }
                }
            }
        }


        /// <summary>
        /// Function to execute a Insert, Update, delete query! 
        /// </summary>
        /// <param name="command">A <seealso cref="Command"/> object which contains Query and parameters</param>
        /// <returns>An int which represent The number of rows affected by the query execution</returns>
        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            { 
                using (SqlCommand cmd = CreateCommand(command, connection))
                {   
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Function that returns the result of aggregate queries (SUM, Count, AVG,...)
        /// or of a query containing an OUTPUT (Insert into table(...) output Inserted.id Values(...))
        /// </summary>
        /// <returns>An object = The first column of the first row in the result set, or a DBNull if the result set is empty</returns>
        /// <remarks>The connection is NOT OPENED after CreateCommand_function</remarks>
        /// 
        public object ExecuteScalar(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                { 
                    connection.Open();
                    object o = cmd.ExecuteScalar();
                    return (o is DBNull) ? null : o; //If the Query return is null(DBNull) , we return the Null (Csharp)
                }
            }
        }

        /// <summary>
        /// Private function to create the SqlConnection Object with connectionstring
        /// </summary>
        /// <returns>A <seealso cref="SqlConnection"/></returns>
        /// <remarks>The connection is NOT OPENED after this function</remarks>
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _ConnectionString;
            return connection;
        }

        /// <summary>
        /// Private function to create the SqlCommand object from our Command and Connection
        /// </summary>
        /// <returns>A <seealso cref="SqlCommand"/> WITH [query + parameters] ASSOCIATED TO a sql connection </returns>
        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand cmd = connection.CreateCommand();
        
            cmd.CommandText = command.Query;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            return cmd;
        }
    }
}
