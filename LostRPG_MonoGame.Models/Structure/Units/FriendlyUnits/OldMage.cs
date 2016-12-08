namespace LostRPG_MonoGame.Models.Structure.Units.FriendlyUnits
{
    using System.ComponentModel.DataAnnotations.Schema;
    using LostRPG_MonoGame.Models.Graphics;
    [Table("OldMages")]
    public class OldMage : FriendlyNPCUnit
    {
        private const int OldMageX = 704;
        private const int OldMageY = 288;
        private const int OldMageSizeX = 30;
        private const int OldMageSizeY = 33;
        private const SpriteType OldMageSprite = SpriteType.OldMageNPC;

        public OldMage() 
            : base(OldMageX, OldMageY, OldMageSizeX, OldMageSizeY, OldMageSprite)
        {
        }

        public string Name { get; set; }

        public string Region  { get; set; } 

        public bool QuestTaken { get; set; }

        public bool QuestCompleete { get; set; }

    }
}
