using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;

namespace Interzoo.DAL.Repositories
{
    public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> where T : IEntity<TKey>, new() where TKey : struct
    {
        // champs + constructeur + prop
         protected Connection _oconn;
        // protected Connection _oconn;
        private string _deleteCommand;
        private string _updateComand;
        private string _insertCommand;
        private string _selectAllCommand;
        private string _selectOneCommand;
        private string _selectTwoCommand;

        protected BaseRepository(string cnString)
        {
            _oconn = new Connection (cnString);
        }

        public string DeleteCommand { get => _deleteCommand; set => _deleteCommand = value; }
        public string UpdateCommand { get => _updateComand; set => _updateComand = value; }
        public string InsertCommand { get => _insertCommand; set => _insertCommand = value; }
        public string SelectAllCommand { get => _selectAllCommand; set => _selectAllCommand = value; }
        public string SelectOneCommand { get => _selectOneCommand; set => _selectOneCommand = value; }
        public string SelectTwoCommand { get => _selectTwoCommand; set => _selectTwoCommand = value; }

        // methodes que ses enfants devront implémenter
        public abstract bool delete(TKey id);
        public abstract IEnumerable<T> getAll();
        public abstract T getOne(TKey id);
        public abstract T insert(T toInsert);
        public abstract bool update(T toUpdate);

        // SES taches
        protected bool delete(Dictionary<string , object> parameters)
        {
            Command cmd = new Command(DeleteCommand);
            foreach(KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            return _oconn.ExecuteNonQuery(cmd) >= 0;
        }
        // ----------------
        protected IEnumerable<T> getAll(Func<SqlDataReader, T> callback, Dictionary<string, object> QueryParameters = null)
        {
            Command cmd = new Command(SelectAllCommand);
            if (QueryParameters != null)
            {
                foreach (KeyValuePair<string, object> item in QueryParameters)
                {
                    cmd.AddParameter(item.Key, item.Value);
                }
            }
            return _oconn.ExecuteReader<T>(cmd, callback);
        }
        // ----------------
        protected T getOne(Func<SqlDataReader, T> callback, Dictionary<string, object> QueryParameters)
        {
            Command cmd = new Command(SelectOneCommand);
            foreach (KeyValuePair<string, object> item in QueryParameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            return _oconn.ExecuteReader<T>(cmd, callback).FirstOrDefault();
        }
        // ------------------
        protected int insert(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(InsertCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            return (int)_oconn.ExecuteScalar(cmd); // on veut récupérer l'incrément ===l'id ajouté
        }
        // -----------------
        protected bool update(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(UpdateCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            return _oconn.ExecuteNonQuery(cmd) >= 0;
        }


    }
}
