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
            UpdateCommand = @"UPDATE Utilisateur SET Nom=@Nom, Prenom=@Prenom, DateDeNaissance=@DateDeNaissance, Courriel=@Courriel,  MotDePasse = @MotDePasse, Photo=@Photo, IsAdmin=@IsAdmin, IdRole=@IdRole
                         WHERE IdUtilisateur=@IdUtilisateur;";
            InsertCommand = @"INSERT INTO  Utilisateur (Nom ,Prenom ,DateDeNaissance ,Courriel ,MotDePasse, Photo,IsAdmin, IdRole) OUTPUT inserted.IdUtilisateur 
                            VALUES(@Nom, @Prenom, @DateDeNaissance, @Courriel, @MotDePasse, @Photo, @IsAdmin, @IdRole )";

            SelectAllCommand = "Select * from Utilisateur";
            SelectOneCommand = $"Select * from Utilisateur where IdUtilisateur=@IdUtilisateur";

        }
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }
        public bool delete(int id, bool isAdmin = false)
        {
            if (isAdmin)
            {
                Dictionary<string, object> Parameters = new Dictionary<string, object>();
                Parameters.Add("@IdUtilisateur", id);
                return base.delete(Parameters);
            }
           throw new InvalidOperationException () ;
        }

        public override IEnumerable<Utilisateur> getAll()
        {
            return base.getAll(mapSqldataRtoUtilisateur);

        }
        // getALL de table Role : 
        public IEnumerable<Role> getAllRolesForRegisterModel()
        {
            
            ///1. -objet Command : cmd contient en lui le dico de param + la query -
            ToolBox.Database.Command cmd = new ToolBox.Database.Command("Select * from Role ");
            ///2. -  dico of parameters -
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> item in QueryParameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
     
            return _oconn.ExecuteReader<Role>(cmd, mapSqldataRtoRole);
            ///      
        }
     
        public override Utilisateur getOne(int id)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IdUtilisateur", id);
            return base.getOne(mapSqldataRtoUtilisateur, Parameters);
        }
        //----
        public Utilisateur verifLogin(Utilisateur u)
        {
            SelectOneCommand = $"Select * from Utilisateur WHERE Courriel=@Courriel AND MotDePasse = @MotDePasse";
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Courriel", u.Courriel);
            Parameters.Add("@MotDePasse", u.HashMDP);
            return base.getOne(mapSqldataRtoUtilisateur, Parameters);
        }
        // ----
        public override Utilisateur insert(Utilisateur toInsert)
        {
            Dictionary<string, object> Parameters = utilisateurToDico(toInsert);
            int id = base.insert(Parameters);
            toInsert.IdUtilisateur = id;
            return toInsert;
        }
       

        public override bool update(Utilisateur toUpdate)
        {
            Dictionary<string, object> parameters = utilisateurToDico(toUpdate);
            return base.update(parameters);
        }

        // -----------
        // -----------
        private Utilisateur mapSqldataRtoUtilisateur(SqlDataReader sqdr) // RETOUR <- DB
        {
            return new Utilisateur()
            {
                IdUtilisateur = (int)sqdr["IdUtilisateur"],
                Nom = sqdr["Nom"].ToString(),
                Prenom = sqdr["Prenom"].ToString(),
                Courriel = sqdr["Courriel"].ToString(),
                DateDeNaissance = (DateTime)sqdr["DateDeNaissance"],
                Photo = sqdr["Photo"].ToString(), // sera vide
                IsAdmin = (bool)sqdr["IsAdmin"],
                IdRole = (int)sqdr["IdRole"]

            };
        }
        
        private Dictionary<string, object> utilisateurToDico(Utilisateur toInsert) // Etape pour ALLER -> DB
        {
            return new Dictionary<string, object>
            {
               
                ["IdUtilisateur"] = toInsert.IdUtilisateur,
                ["Nom"] = toInsert.Nom,
                ["Prenom"] = toInsert.Prenom,
                ["Courriel"] = toInsert.Courriel,
                ["MotDePasse"] = toInsert.HashMDP, 
                ["DateDeNaissance"] = toInsert.DateDeNaissance,
                ["Photo"] = toInsert.Photo,
                ["IsAdmin"] = toInsert.IsAdmin,
                ["IdRole"] = toInsert.IdRole                
            };
        }
        // -----------

        private Role mapSqldataRtoRole(SqlDataReader sqdr) // RETOUR <- DB
        {
            return new Role()
            {
                IdRole = (int)sqdr["IdRole"],
                TypeRole = sqdr["TypeRole"].ToString()               
            };
        }



    }
}
