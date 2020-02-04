using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class AnimalRepository : BaseRepository<Animal, int>
    {
        public AnimalRepository(string cnString) : base(cnString)
        {
            DeleteCommand = @"DELETE * FROM Animal WHERE IdAnimal=@IdAnimal";
            UpdateCommand = @"UPDATE Animal SET Nom=@Nom, NomScientifique=@NomScientifique, RegionOrigine=@RegionOrigine, IdCategorie=@IdCategorie, Photo=@Photo   WHERE IdAnimal=@IdAnimal;";
            InsertCommand = @"INSERT INTO  Animal (Nom ,NomScientifique ,RegionOrigine ,IdCategorie , Photo) OUTPUT inserted.IdAnimal 
                            VALUES(@Nom, @NomScientifique, @RegionOrigine, @IdCategorie, @Photo )";

            SelectAllCommand = "Select * from Animal";
            SelectOneCommand = "Select * from Animal where IdAnimal=@IdAnimal";
        }

        public override bool delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdAnimal", id);
            return base.delete(Parameters);
        }

        public override IEnumerable<Animal> getAll()
        {
            return base.getAll(mapSqlDataRtoAnimal);
        }
        public  IEnumerable<Animal> getAllOfOneGodparent(int idUtilisateur)
        {
            SelectAllCommand = @"Select * from Animal 
                INNER JOIN AnimalParrain on Animal.IdAnimal=AnimalParrain.idAnimal
                INNER JOIN Parrain on Parrain.IdParrain=AnimalParrain.idParrain
                INNER JOIN Utilisateur on Utilisateur.IdUtilisateur=Parrain.IdUtilisateur
                WHERE Utilisateur.IdUtilisateur=@IdUtilisateur";

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdUtilisateur", idUtilisateur);                       
            return base.getAll(mapSqlDataRtoAnimal, Parameters);
        }

        public override Animal getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdAnimal", id);
            return base.getOne(mapSqlDataRtoAnimal, Parameters);
        }

        public override Animal insert(Animal toInsert)
        {
            Dictionary<string, object> Parameters = AnimalToDico(toInsert);
            int id = base.insert(Parameters);
            toInsert.IdAnimal = id;
            return toInsert;
        }
        public override bool update(Animal toUpdate)
        {
            Dictionary<string, object> parameters = AnimalToDico(toUpdate);
            return base.update(parameters);
        }

        //------------
        // --------------------
        private Animal mapSqlDataRtoAnimal(SqlDataReader sqdr)
        {
            return new Animal()
            {
                IdAnimal = (int)sqdr["IdAnimal"],
                Nom = sqdr["Nom"].ToString(),
                NomScientifique = sqdr["RegionOrigine"].ToString(),
                RegionOrigine = sqdr["Courriel"].ToString(),
                Photo = sqdr["photo"].ToString(),
                IdCategorie = (int)sqdr["IdCategorie"]
            };
        }
       
        private Dictionary<string, object> AnimalToDico(Animal toInsert)
        {
            return new Dictionary<string, object>
            {
                ["Nom"] = toInsert.Nom,
                ["NomScientifique"] = toInsert.NomScientifique,
                ["RegionOrigine"] = toInsert.RegionOrigine,
                ["Photo"] = toInsert.Photo,
                ["IdCategorie"] = toInsert.IdCategorie
            };
        }
        // -----------
        // -----------
       
    }
}
