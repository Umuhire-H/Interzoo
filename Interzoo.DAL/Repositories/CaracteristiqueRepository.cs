using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class CaracteristiqueRepository : BaseRepository<Caracteristique, int>
    {
        public CaracteristiqueRepository(string cnstr) : base(cnstr)
        {

            DeleteCommand = @"DELETE * FROM Caracteristique
                                    WHERE IdCaracteristique=@IdCaracteristique";
            UpdateCommand = @"UPDATE Caracteristique SET TypeCaracteristique=@TypeCaracteristique 
                                    WHERE Caracteristique=@IdCaracteristique";
            InsertCommand = @"INSERT INTO  Caracteristique (IdCaracteristique, TypeCaracteristique)
                                    VALUES (@IdCaracteristique, @TypeCaracteristique)";

            SelectAllCommand = "Select * from Caracteristique";
            SelectOneCommand = @"Select * from Caracteristique 
                                    WHERE IdCaracteristique=@IdCaracteristique";
        }
        public override bool delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdCaracteristique", id);
            return base.delete(Parameters);
        }

        public override IEnumerable<Caracteristique> getAll()
        {
            return base.getAll(sqlDataRtoCaracteristique);
        }
        //
        public  IEnumerable<Caracteristique> getAllCaractTYPEOfOneAnimal(int id)
        {
            SelectOneCommand = @"Select * from Caracteristique 
                              INNER JOIN AnimalCaracteristique on AnimalCaracteristique.IdCaracteristique=Caracteristique.IdCaracteristique
                              INNER JOIN Animal on Animal.IdAnimal=AnimalCaracteristique.IdAnimal
                                    WHERE IdAnimal=@IdAnimal";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdAnimal", id);
            return base.getAll(sqlDataRtoCaracteristique, Parameters);
        }

        public override Caracteristique getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdCaracteristique", id);
            return base.getOne(sqlDataRtoCaracteristique, Parameters);
        }

        public override Caracteristique insert(Caracteristique toInsert)
        {
            Dictionary<string, object> Parameters = CaracteristiqueToDico(toInsert);
            toInsert.IdCaracteristique = base.insert(Parameters);
            return toInsert;
        }

        public override bool update(Caracteristique toUpdate)
        {
            Dictionary<string, object> parameters = CaracteristiqueToDico(toUpdate);
            return base.update(parameters);
        }
        //MAPPER DAL
        private Dictionary<string, object> CaracteristiqueToDico(Caracteristique toInsert)
        {
            return new Dictionary<string, object>
            {
                ["IdCaracteristique"] = toInsert.IdCaracteristique,
                ["TypeCaracteristique"] = toInsert.TypeCaracteristique              
            };
        }
        private Caracteristique sqlDataRtoCaracteristique(SqlDataReader sqdr)
        {
            return new Caracteristique()
            {
                IdCaracteristique = (int) sqdr["IdCaracteristique"],
                TypeCaracteristique = sqdr["TypeCaracteristique"].ToString()
            };
}
    }
}
