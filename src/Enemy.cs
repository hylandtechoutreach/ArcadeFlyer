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

        // Cool down timer for projectile firing
        private Timer projectileCoolDown;

        // Initialize an enemy
        public Enemy(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            // Initialize values
            this.root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;
            this.velocity = new Vector2(-1.0f, 5.0f);
            this.projectileCoolDown = new Timer(2.0f);

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
            position += velocity;

            // Bounce on top and bottom
            if (position.Y < 0 || position.Y > (root.ScreenHeight - SpriteHeight))
            {
                velocity.Y *= -1;
            }

            // Fire a projectile if not currently cooling down
            if (!projectileCoolDown.Active)
            {
                // Generate the projectile information
                Vector2 projectilePosition = new Vector2(position.X, position.Y + SpriteHeight / 2);
                Vector2 projectileVelocity = new Vector2(-5.0f, 0.0f);

                // Fire the projectile from the main game
                root.FireProjectile(projectilePosition, projectileVelocity, ProjectileType.Enemy);

                // Kick off the cool down process
                projectileCoolDown.StartTimer();
            }

            // Update the cool down timer
            projectileCoolDown.Update(gameTime);
        }
    }
}
