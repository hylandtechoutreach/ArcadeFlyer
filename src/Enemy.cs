using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // A little evil thing
    class Enemy : Sprite
    {
        // A reference to the game that will contain this enemy
        private ArcadeFlyerGame root;

        // The the velocity for this enemy
        private Vector2 velocity;

        // Initialize an enemy
        public Enemy(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            // Initialize values
            this.root = root;
            this.Position = position;
            this.SpriteWidth = 128.0f;
            this.velocity = new Vector2(-1.0f, 5.0f);

            // Load the content for this enemy
            LoadContent();
        }

        // Loads all the assets for this enemy
        public void LoadContent()
        {
            // Get the Enemy image
            this.SpriteImage = root.Content.Load<Texture2D>("Enemy");
        }

        // Called each frame
        public void Update(GameTime gameTime)
        {
            // Handle movement
            Position += velocity;

            // Bounce on top and bottom
            if (Position.Y < 0 || Position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }
        }
    }
}
