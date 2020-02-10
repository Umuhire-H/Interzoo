using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class CategorieRepository : BaseRepository<Categorie, int>
    {
        public CategorieRepository(string cnString) : base(cnString)
        {
            DeleteCommand = @"DELETE * FROM Categorie WHERE IdCategorie=@IdCategorie";
            UpdateCommand = @"UPDATE Categorie SET TypeCategorie=@TypeCategorie WHERE IdCategorie=@IdCategorie";
            InsertCommand = @"INSERT INTO  Categorie (TypeCategorie ) OUTPUT inserted.IdCategorie 
                            VALUES(@TypeCategorie)";

            SelectAllCommand = "Select * from Categorie";
            SelectOneCommand = "Select * from Categorie where IdCategorie=@IdCategorie";
        }
        public override bool delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdCategorie", id);
            return base.delete(Parameters);
        }

        public override IEnumerable<Categorie> getAll()
        {
            return base.getAll(mapSqlDataRtoCategorie);

        }

        public override Categorie getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdCategorie", id);
            return base.getOne(mapSqlDataRtoCategorie, Parameters);
        }

        public override Categorie insert(Categorie toInsert)
        {
            Dictionary<string, object> Parameters = categorieToDico(toInsert);
            int id = base.insert(Parameters);
            toInsert.IdCategorie = id;
            return toInsert;
        }

        public override bool update(Categorie toUpdate)
        {
            Dictionary<string, object> parameters = categorieToDico(toUpdate);
            return base.update(parameters);
        }
        // mappers

        private Dictionary<string, object> categorieToDico(Categorie toInsert) // Etape pour ALLER -> DB
        {
            return new Dictionary<string, object>
            {

                ["TypeCategorie"] = toInsert.TypeCategorie,
                ["IdCategorie"] = toInsert.IdCategorie
            };
        }
           

        private Categorie mapSqlDataRtoCategorie(SqlDataReader sqdr) // RETOUR <- DB
        {
            return new Categorie()
            {
                IdCategorie = (int)sqdr["IdCategorie"],
                TypeCategorie = sqdr["TypeCategorie"].ToString()
            };
        }
    }
}
