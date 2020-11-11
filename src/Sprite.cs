using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // Sprite base class, contains basic sprite functionality
    class Sprite
    {
        // The current position of the sprite
        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        // An image texture for the sprite
        private Texture2D spriteImage;
        public Texture2D SpriteImage
        {
            get { return spriteImage; }
            set { spriteImage = value; }
        }

        // The width of the sprite
        private float spriteWidth;
        public float SpriteWidth
        {
            get { return spriteWidth; }
            set { spriteWidth = value; }
        }

        // The height of the sprite
        public float SpriteHeight
        {
            get
            {
                // Calculated based on the width
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }

        // The properly scaled position rectangle for the sprite
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
            }
        }
        
        // Initialize a sprite
        public Sprite(Vector2 position)
        {
            // Initialize values
            this.position = position;
        }

        // Does this Sprite overlap the given Sprite?
        public bool Overlaps(Sprite otherSprite)
        {
            // Check if PositionRectangle intersects with the other sprite's rectangle
            bool doesOverlap = this.PositionRectangle.Intersects(otherSprite.PositionRectangle);
            return doesOverlap;
        }

        // Draw the sprite
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
        }
    }
}
