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
        private ToolBox.Database.Connection _myOconn;
        public UtilisateurRepository (string cnstring) : base(cnstring)
        {
            DeleteCommand = @"DELETE FROM Utilisateur WHERE IdUtilisateur=@IdUtilisateur";
            UpdateCommand = @"UPDATE Utilisateur SET Nom=@Nom, Prenom=@Prenom, DateDeNaissance=@DateDeNaissance, Courriel=@Courriel,  MotDePasse = @MotDePasse, Photo=@Photo, IsAdmin=@IsAdmin, IdRole=@IdRole
                         WHERE IdUtilisateur=@IdUtilisateur;";
            InsertCommand = @"INSERT INTO  Utilisateur (Nom ,Prenom ,DateDeNaissance ,Courriel ,MotDePasse, Photo,IsAdmin, IdRole) OUTPUT inserted.IdUtilisateur 
                            VALUES(@Nom, @Prenom, @DateDeNaissance, @Courriel,@MotDePasse, @Photo, @IsAdmin, @IdRole )";

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
        public IEnumerable<Role> getAllRolesForRegisterModel(string sameCnstr)
        {
            // SelectAllCommand = "Select * from Role INNER JOIN Utilisateur on Role.IdRole=Utilisateur.IdRole";
            SelectAllCommand = "Select * from Role ";
            //----
            
            ///1. -objet Command : cmd contient en lui le dico de param + la query -
            ToolBox.Database.Command cmd = new ToolBox.Database.Command(SelectAllCommand);
            ///2. -  dico of parameters -
            Dictionary<string, object> QueryParameters = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> item in QueryParameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }
            ///3. -objet de connection-
            _myOconn = new ToolBox.Database.Connection(sameCnstr);
            return _myOconn.ExecuteReader<Role>(cmd, mapSqldataRtoRole);
            ///      
        }
     
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
       

        public override bool update(Utilisateur toUpdate)
        {
            Dictionary<string, object> parameters = utilisateurToDico(toUpdate);
            return base.update(parameters);
        }

        // -----------
        // -----------
        private Utilisateur mapSqldataRtoUtilisateur(SqlDataReader sqdr)
        {
            return new Utilisateur()
            {
                IdUtilisateur = (int)sqdr["IdUtilisateur"],
                Nom = sqdr["Nom"].ToString(),
                Prenom = sqdr["Prenom"].ToString(),
                Courriel = sqdr["Courriel"].ToString(),
                // MotDePasse = sqdr["MotDePasse"].ToString(),
                DateDeNaissance = (DateTime)sqdr["DateDeNaissance"]
            };
        }
        
        private Dictionary<string, object> utilisateurToDico(Utilisateur toInsert)
        {
            return new Dictionary<string, object>
            {
                ["Nom"] = toInsert.Nom,
                ["Prenom"] = toInsert.Prenom,
                ["Courriel"] = toInsert.Courriel,
                ["MotDePasse"] = toInsert.HashMDP, // <<<<<=====================
                ["DateDeNaissance"] = toInsert.DateDeNaissance
            };
        }
        // -----------

        private Role mapSqldataRtoRole(SqlDataReader sqdr)
        {
            return new Role()
            {
                IdRole = (int)sqdr["IdRole"],
                TypeRole = sqdr["TypeRole"].ToString()               
            };
        }



    }
}
