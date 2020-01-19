using Interzoo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Repositories
{
    public class UtilisateurRepository : BaseRepository<Utilisateur, int>
    {
        public UtilisateurRepository (string cnstring) : base(cnstring)
        {
            DeleteCommand = @"DELETE FROM Utilisateur WHERE IdUtilisateur=@IdUtilisateur";
            UpdateCommand = @"UPDATE Utilisateur SET Nom=@Nom, Prenom=@Prenom, DateDeNaissance=@DateDeNaissance, Courriel=@Courriel,  MotDePasse = @MotDePasse, Photo=@Photo 
                         WHERE IdUtilisateur=@IdUtilisateur;";
            InsertCommand = @"INSERT INTO  Utilisateur (Nom ,Prenom ,Surnom ,Courriel ,MotDePasse, Photo) OUTPUT inserted.IdUtilisateur 
                            VALUES(@Nom, @Prenom, @Surnom, @Courriel,@MotDePasse, @Photo )";

            SelectAllCommand = "Select * from Utilisateur";
            SelectOneCommand = $"Select * from Utilisateur where IdUtilisateur=@IdUtilisateur";

        }
        public override bool delete(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdUtilisateur", id);
            return base.delete(Parameters);
        }

        public override IEnumerable<Utilisateur> getAll()
        {
            return base.getAll(mapSqldataRtoUtilisateur);

        }
        // -----------
        private Utilisateur mapSqldataRtoUtilisateur (SqlDataReader sqdr)
        {
            return new Utilisateur()
            {
                IdUtilisateur = (int)sqdr["IdUtilisateur"],
                Nom = sqdr["Nom"].ToString(),
                Prenom = sqdr["Prenom"].ToString(),
                Courriel = sqdr["Courriel"].ToString(),
                MotDePasse = sqdr["MotDePasse"].ToString(),
                DateDeNaissance = (DateTime)sqdr["DateDeNaissance"]
            };
        }
        // -----------
        public override Utilisateur getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdUtilisateur", id);
            return base.getOne(mapSqldataRtoUtilisateur, Parameters);
        }

        public override Utilisateur insert(Utilisateur toInsert)
        {
            Dictionary<string, object> Parameters = utilisateurToDico(toInsert);
            int id = base.insert(Parameters);
            toInsert.IdUtilisateur = id;
            return toInsert;
        }
        //------------
        private Dictionary<string, object> utilisateurToDico(Utilisateur toInsert)
        {
            return new Dictionary<string, object>
            {
                ["Nom"] = toInsert.Nom,
                ["Prenom"] = toInsert.Prenom,
                ["Courriel"] = toInsert.Courriel,
                ["MotDePasse"] = toInsert.HashMDP,
                ["DateDeNaissance"] =  toInsert.DateDeNaissance
            };
        }
        // -----------

        public override bool update(Utilisateur toUpdate)
        {
            Dictionary<string, object> parameters = utilisateurToDico(toUpdate);
            return base.update(parameters);
        }
    }
}
