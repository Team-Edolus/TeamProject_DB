namespace LostRPG.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LostRPG.Models.Structure.Units.EnemyUnits;

    public class RegionEntitiesDBM
    {
        public RegionEntitiesDBM()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<GiantCrab1> Crabs { get; set; }
    }
}
