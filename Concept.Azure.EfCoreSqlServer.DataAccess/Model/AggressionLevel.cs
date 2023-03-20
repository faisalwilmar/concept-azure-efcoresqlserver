using System.ComponentModel.DataAnnotations;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Model
{
    public class AggressionLevel
    {
        [Key]
        public int Id { get; set; }
        
        public string AggressionName { get; set; }
    }
}
