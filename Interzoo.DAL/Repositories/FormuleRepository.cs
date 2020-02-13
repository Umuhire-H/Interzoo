using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class FormuleRepository : BaseRepository<Formule, int>
    {
        public FormuleRepository(string cnstr) : base(cnstr)
        {
            DeleteCommand = @"DELETE * FROM Formule
                                    WHERE IdFormule=@IdFormule";
            UpdateCommand = @"UPDATE Formule 
                            SET Nom = @Nom,  Description = @Description,  Prix = @Prix, DateDebut = @DateDebut,  DateFin = @DateFin
                                    WHERE IdFormule=@IdFormule";

            InsertCommand = @"INSERT INTO  Formule (Nom, Description,  Prix, DateDebut,  DateFin)
                                     OUTPUT inserted.IdFormule
                                    VALUES (@Nom, @Description, @Prix, @DateDebut, @DateFin )";

            SelectAllCommand = "Select * from Formule";
            SelectOneCommand = @"Select * from Formule 
                                    WHERE IdFormule=@IdFormule";
        }
        public override bool delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdFormule", id);
            return base.delete(Parameters);
        }

        public override IEnumerable<Formule> getAll()
        {
            return base.getAll(sqldataRtoFormule);
        }
        public  IEnumerable<Formule> getAllFormulesOneUtilisateur(int idUtilisateur)
        {
            SelectAllCommand = @"Select * from Formule 
                INNER JOIN Parrain on Parrain.IdFormule=Formule.idFormule
                INNER JOIN Utilisateur on Utilisateur.IdUtilisateur=Parrain.IdUtilisateur
                WHERE Utilisateur.IdUtilisateur=@IdUtilisateur";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdUtilisateur", idUtilisateur);
            return base.getAll(sqldataRtoFormule, Parameters);
        }

        public override Formule getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdFormule", id);
            return base.getOne(sqldataRtoFormule, Parameters);
        }

        public override Formule insert(Formule toInsert)
        {
            Dictionary<string, object> Parameters = formuleToDico(toInsert);
            int id = base.insert(Parameters);
            toInsert.IdFormule = id;
            return toInsert;
        }
        public int insertInParrainTable(int idFormule)
        {
            InsertCommand = @"INSERT INTO  Parrain (IdFormule)
                                     OUTPUT inserted.IdFormule
                                    VALUES (@IdFormule)";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdFormule", idFormule);
            
           return base.insert(Parameters);
            
        }

        public override bool update(Formule toUpdate)
        {
            Dictionary<string, object> parameters = formuleToDico(toUpdate);
            return base.update(parameters);
        }
        //mappers
        private Formule sqldataRtoFormule(SqlDataReader sqdr) // RETOUR <- DB
        {
            return new Formule()
            {
                IdFormule = (int)sqdr["IdFormule"],
                Nom = sqdr["Nom"].ToString(),
                Description = sqdr["Description"].ToString(),
                Prix = (double)sqdr["Prix"],
                DateDebut = (DateTime)sqdr["DateDebut"],
                DateFin = (DateTime)sqdr["DateFin"]
            };
        }
        private Dictionary<string, object> formuleToDico(Formule toInsert) // Etape pour ALLER -> DB
        {
            return new Dictionary<string, object>
            {

                ["IdFormule"] = toInsert.IdFormule,
                ["Nom"] = toInsert.Nom,
                ["Description"] = toInsert.Description,
                ["Prix"] = toInsert.Prix,
                ["DateDebut"] = toInsert.DateDebut,
                ["DateFin"] = toInsert.DateFin
            };

        }
    }
}
