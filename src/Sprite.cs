using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    class Sprite
    {
        protected Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        private Texture2D spriteImage;
        public Texture2D SpriteImage
        {
            get
            {
                return spriteImage;
            }
            set
            {
                spriteImage = value;
            }
        }
        private float spriteWidth;
        public float SpriteWidth
        {
            get
            {
                return spriteWidth;
            }
            set
            {
                spriteWidth = value;
            }
        }
        public float SpriteHeight
        {
            get
            {
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }

        public Rectangle PositionRectangle 
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
            }
        }

        public Sprite(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
        }


    }
}