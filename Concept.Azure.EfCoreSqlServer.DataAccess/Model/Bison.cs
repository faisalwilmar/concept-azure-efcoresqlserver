using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concept.Azure.EfCoreSqlServer.DataAccess.Model
{
    public class Bison
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Age { get; set; }

        public bool IsAlive { get; set; }

        // reference https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx

        public AggressionLevel AggressionLevel { get; set; } // this will generate AggressionLevelId in the database

        [ForeignKey("BiomeRefId")] // this will generate BiomeRefId in the database instead of BiomeCategoryId
        public BiomeCategory BiomeCategory { get; set; }
    }
}
