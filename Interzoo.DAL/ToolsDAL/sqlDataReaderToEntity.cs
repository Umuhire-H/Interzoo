using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.ToolsDAL
{
    public static class sqlDataReaderToEntity where T:IEntity
    {
        public static <T> mapSqldataRtoUtilisateur(SqlDataReader sqdr)
        {
            return new T()
            {
                IdUtilisateur = (int)sqdr["IdUtilisateur"],
                Nom = sqdr["Nom"].ToString(),
                Prenom = sqdr["Prenom"].ToString(),
                Courriel = sqdr["Courriel"].ToString(),
                MotDePasse = sqdr["MotDePasse"].ToString(),
                DateDeNaissance = (DateTime)sqdr["DateDeNaissance"]
            };
        }
    }
}
