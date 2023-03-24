using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Model.Base
{
    public class ModelBase
    {
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ModifiedDateUtc { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class IntIdModelBase : ModelBase
    {
        [Key]
        public int Id { get; set; }
    }

    public class GuidIdModelBase : ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
