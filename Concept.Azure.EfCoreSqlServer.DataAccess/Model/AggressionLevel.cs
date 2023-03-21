using Concept.Azure.EfCoreSqlServer.DataAccess.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Model
{
    public class AggressionLevel : IntIdModelBase
    {   
        public string AggressionName { get; set; }
    }
}
