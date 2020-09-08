using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // A little evil thing
    class Enemy
    {
        // A reference to the game that will contain this enemy
        private ArcadeFlyerGame root;

        // The current position of this enemy
        private Vector2 position;

        // An image texture for this enemy sprite
        private Texture2D spriteImage;

        // The width of this sprite
        private float spriteWidth;

        // The the velocity for this enemy
        private Vector2 velocity;

        // The height of this sprite
        public float SpriteHeight
        {
            get
            {
                // Calculated based on the width
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }
        
        // The properly scaled position rectangle for this enemy sprite
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
            }
        }

        // Initialize an enemy
        public Enemy(ArcadeFlyerGame root, Vector2 position)
        {
            // Initialize values
            this.root = root;
            this.position = position;
            this.spriteWidth = 128.0f;
            this.velocity = new Vector2(-1.0f, 5.0f);

            // Load the content for this enemy
            LoadContent();
        }

        // Loads all the assets for this enemy
        public void LoadContent()
        {
            // Get the Enemy image
            this.spriteImage = root.Content.Load<Texture2D>("Enemy");
        }

        // Called each frame
        public void Update(GameTime gameTime)
        {
            // Handle movement
            position += velocity;

            // Bounce on top and bottom
            if (position.Y < 0 || position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }
        }

        // Draw this enemy
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Use the Sprite Batch to draw
            spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
        }
    }
}
