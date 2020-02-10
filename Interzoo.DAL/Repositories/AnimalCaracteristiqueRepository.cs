using Interzoo.DAL.Infra;
using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class AnimalCaracteristiqueRepository : BaseRepository<AnimalCaracteristique, CompositeKey<int, int>>
    {
        public AnimalCaracteristiqueRepository(string cnString):base(cnString)
        {
            DeleteCommand = @"DELETE * FROM AnimalCaracteristique
                                    WHERE IdAnimal=@IdAnimal AND IdCaracteristique=@IdCaracteristique";
            UpdateCommand = @"UPDATE AnimalCaracteristique SET NomCaracteristique=@NomCaracteristique 
                                    WHERE IdAnimal=@IdAnimal AND IdCaracteristique=@IdCaracteristique";
            InsertCommand = @"INSERT INTO  AnimalCaracteristique (IdAnimal, IdCaracteristique, NomCaracteristique)
                                    VALUES (@IdAnimal, @IdCaracteristique, @NomCaracteristique)";

            SelectAllCommand = "Select * from AnimalCaracteristique";
            SelectOneCommand = @"Select * from AnimalCaracteristique 
                                    WHERE IdAnimal=@IdAnimal AND IdCaracteristique=@IdCaracteristique";
        }
        public override bool delete(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary <string, object>();
            Parameters.Add("@IdAnimal", id.PK1);
            Parameters.Add("@IdCaracteristique", id.PK2);
            return base.delete(Parameters);
        }

        public override IEnumerable<AnimalCaracteristique> getAll()
        {
            return base.getAll(mapSqlDRtoAnimalCaracteristique);
        }
        public IEnumerable<AnimalCaracteristique> getAllCaractVALUEOfOneAnimal (int idAnimal/*CompositeKey<int, int> id*/)
        {
            SelectOneCommand = @"Select * from AnimalCaracteristique 
                                    WHERE IdAnimal=@IdAnimal";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdAnimal", idAnimal);
            //Parameters.Add("@IdAnimal", id.PK1);
            //Parameters.Add("@IdCaracteristique", id.PK2);
            return base.getAll(mapSqlDRtoAnimalCaracteristique, Parameters);
        }
        

        public override AnimalCaracteristique getOne(CompositeKey<int, int> id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdAnimal", id.PK1);
            Parameters.Add("@IdCaracteristique", id.PK2);
            return base.getOne(mapSqlDRtoAnimalCaracteristique, Parameters);
        }

        public override AnimalCaracteristique insert(AnimalCaracteristique toInsert)
        {
            Dictionary<string, object> Parameters = mapAnimalCaractToDico(toInsert);
            base.insert(Parameters);
            return toInsert;

        }

        public override bool update(AnimalCaracteristique toUpdate)
        {
            Dictionary<string, object> Parameters = mapAnimalCaractToDico(toUpdate);
            return base.update(Parameters);
           
        }
        // MAPs
        private AnimalCaracteristique mapSqlDRtoAnimalCaracteristique(SqlDataReader sqlr)
        {
            return new AnimalCaracteristique()
            {
                IdAnimal = (int)sqlr["IdAnimal"],
                IdCaracteristique = (int)sqlr["IdCaracteristique"],
                NomCaracteristique = sqlr["NomCaracteristique"].ToString()
            };
        }
        private Dictionary<string, object> mapAnimalCaractToDico(AnimalCaracteristique toInsert)
        {
            return new Dictionary<string, object>()
            {
                ["IdAnimal"] = toInsert.IdAnimal,
                ["IdCaracteristique"] = toInsert.IdCaracteristique,
                ["NomCaracteristique"] = toInsert.NomCaracteristique
            };
        }
    }
}
