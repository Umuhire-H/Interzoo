using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Toolbox namespace to use with using on the others project
/// </summary>
namespace ToolBox.Database 
{
    public class Command
    {
        /// <summary>
        /// A string property to store the query to execute
        /// </summary>
        internal string Query { get; private set; }

        /// <summary>
        /// A dictionnary property to store parameters for the Query
        /// </summary> 
        internal Dictionary<string, object> Parameters { get; private set; }

        /// <summary>
        /// The Command constructor which initialize the Query from our parameter and initialize 
        /// the Parameters property with a new Dictionary
        /// </summary>
        /// <param name="query">The query we want to execute</param>
        /// <example>
        /// <c>Command cmd = new Command("Select * from Table Where id=@id");</c>
        /// </example>
        public Command(string query)
        {
            Parameters = new Dictionary<string, object>();
            Query = query;
        }

        /// <summary>
        /// Method to add the parameters necessary for the execution of our sql command. 
        /// These parameters will be stored in the Parameters property
        /// </summary>
        /// <param name="parameterName">The name of the query parameter for which we want to add a value</param>
        /// <param name="value">The value of the query parameter</param>
        /// <example>
        /// If you have this query : Select * from Table Where id=@id.
        /// You can call this method with
        /// <c>cmd.AddParameter("id",1)</c>
        /// </example>
        public void AddParameter(string parameterName, object value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
