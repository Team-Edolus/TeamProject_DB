namespace LostRPG_MonoGame.Models.Graphics
{
    using System;
    using LostRPG_MonoGame.Models.Interfaces;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    public class TextureHandler : ITextureHandler
    {
        private Texture2D startRegionBGImage;
        private Texture2D valleyRegionBGImage;
        private Texture2D mageLayerRegionBGImage;
        private Texture2D mageHouseRegionBGImage;
        private Texture2D characterImage;
        private Texture2D oldMageNPCImage;
        private Texture2D boar1Image;
        private Texture2D giantCrab1Image;
        private Texture2D backgroundImage;
        private Texture2D swordImage;
        private Texture2D axeImage;
        private Texture2D pineappleImage;
        private Texture2D shieldImage;

        public TextureHandler(ContentManager content)
        {
            this.Content = content;
            this.LoadResources();
        }

        private ContentManager Content { get; }

        public Texture2D GetSpriteTexture(IRenderable renderableObject)
        {
            Texture2D texture;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.StartRegionBG:
                    texture = this.startRegionBGImage;
                    break;
                case SpriteType.ValleyRegionBG:
                    texture = this.valleyRegionBGImage;
                    break;
                case SpriteType.MageLayerRegionBG:
                    texture = this.mageLayerRegionBGImage;
                    break;
                case SpriteType.MageHouseRegionBG:
                    texture = this.mageHouseRegionBGImage;
                    break;
                case SpriteType.Char1:
                    texture = this.characterImage;
                    break;
                case SpriteType.OldMageNPC:
                    texture = this.oldMageNPCImage;
                    break;
                case SpriteType.Boar1:
                    texture = this.boar1Image;
                    break;
                case SpriteType.GiantCrab1:
                    texture = this.giantCrab1Image;
                    break;
                case SpriteType.Background:
                    texture = this.backgroundImage;
                    break;
                case SpriteType.Sword:
                    texture = this.swordImage;
                    break;
                case SpriteType.Axe:
                    texture = this.axeImage;
                    break;
                case SpriteType.Pineapple:
                    texture = this.pineappleImage;
                    break;
                case SpriteType.Shield:
                    texture = this.shieldImage;
                    break;
                default:
                    throw new ArgumentException("No such SpriteType!");
            }

            return texture;
        }

        private void LoadResources()
        {
            this.startRegionBGImage = this.Content.Load<Texture2D>("startRegion_v1_720p");
            this.valleyRegionBGImage = this.Content.Load<Texture2D>("valleyRegion_v1_720p");
            this.mageLayerRegionBGImage = this.Content.Load<Texture2D>("mageLayerRegion_v1_720p");
            this.mageHouseRegionBGImage = this.Content.Load<Texture2D>("mageHouseRegion_v1_720p");
            this.characterImage = this.Content.Load<Texture2D>("Character_16x24");
            this.oldMageNPCImage = this.Content.Load<Texture2D>("oldMageNPC_30x33");
            this.boar1Image = this.Content.Load<Texture2D>("Boar_39x24");
            this.giantCrab1Image = this.Content.Load<Texture2D>("crab1_22x16");
            this.backgroundImage = this.Content.Load<Texture2D>("background_720p");
            this.swordImage = this.Content.Load<Texture2D>("Sword_6x16");
            this.axeImage = this.Content.Load<Texture2D>("AxeDefault");
            this.pineappleImage = this.Content.Load<Texture2D>("pineapple35x32");
            this.shieldImage = this.Content.Load<Texture2D>("shield32x32");
        }
    }
}
