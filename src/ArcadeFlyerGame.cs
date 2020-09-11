using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcadeFlyer2D
{
    // The Game itself
    class ArcadeFlyerGame : Game
    {
        // Graphics Manager
        private GraphicsDeviceManager graphics;

        // Sprite Drawer
        private SpriteBatch spriteBatch;

        // The player
        private Player player;

        // An enemy
        private Enemy enemy;

        // List of all projectiles on the screen
        private List<Projectile> projectiles;

        // Projectile image for player
        private Texture2D playerProjectileSprite;

        // Projectile image for enemy
        private Texture2D enemyProjectileSprite;

        // Screen width
        private int screenWidth = 1600;
        public int ScreenWidth
        {
            get { return screenWidth; }
            private set { screenWidth = value; }
        }

        // Screen height
        private int screenHeight = 900;
        public int ScreenHeight
        {
            get { return screenHeight; }
            private set { screenHeight = value; }
        }
        
        // Initalized the game
        public ArcadeFlyerGame()
        {
            // Get the graphics
            graphics = new GraphicsDeviceManager(this);

            // Set the height and width
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            // Set up the directory containing the assets
            Content.RootDirectory = "Content";

            // Make mouse visible
            IsMouseVisible = true;

            // Initialize the player to be in the top left
            player = new Player(this, new Vector2(0.0f, 0.0f));
            
            // Initialize an enemy to be on the right side
            enemy = new Enemy(this, new Vector2(screenWidth, 0));

            // Initialize empty list of projectiles
            projectiles = new List<Projectile>();
        }

        // Initialize
        protected override void Initialize()
        {
            base.Initialize();
        }

        // Load the content for the game, called automatically on start
        protected override void LoadContent()
        {
            // Create the sprite batch
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load in textures
            playerProjectileSprite = Content.Load<Texture2D>("PlayerFire");
            enemyProjectileSprite = Content.Load<Texture2D>("EnemyFire");
        }

        // Called every frame
        protected override void Update(GameTime gameTime)
        {   
            // Update base game
            base.Update(gameTime);

            // Update the components
            player.Update(gameTime);
            enemy.Update(gameTime);

            // Loop through projectiles backwards (in order to remove projectiles as needed)
            for (int i = projectiles.Count - 1; i >= 0; i--)
            {
                // Update each projectile
                Projectile p = projectiles[i];
                p.Update();

                // Is this a player projectile?
                bool playerProjectile = p.ProjectileType == ProjectileType.Player;

                // Check if the player collides with this non-player projectile
                if (!playerProjectile && getCollision(player.PositionRectangle, p.PositionRectangle))
                {
                    // There is a collision with the player, remove the projectile
                    projectiles.Remove(p);
                }
                else if (playerProjectile && getCollision(enemy.PositionRectangle, p.PositionRectangle))
                {
                    // There is a collision with the enemy, remove the projectile
                    projectiles.Remove(p);
                }
            }
        }

        // Draw everything in the game
        protected override void Draw(GameTime gameTime)
        {
            // First clear the screen
            GraphicsDevice.Clear(Color.White);

            // Start batch draw
            spriteBatch.Begin();

            // Draw the components
            player.Draw(gameTime, spriteBatch);
            enemy.Draw(gameTime, spriteBatch);

            // Draw all projectiles
            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }

            // End batch draw
            spriteBatch.End();
        }

        // Check for collisions between bounding rectangles
        private bool getCollision(Rectangle spriteBounds1, Rectangle spriteBounds2)
        {
            // Get the center points
            Point sprite1Center = spriteBounds1.Center;
            Point sprite2Center = spriteBounds2.Center;

            // Get the distances between the rectangle centers
            float xDistance = Math.Abs(sprite1Center.X - sprite2Center.X);
            float yDistance = Math.Abs(sprite1Center.Y - sprite2Center.Y);

            // Get the distances required for collision across each axis
            float collisionDistanceX = (spriteBounds1.Width / 2) + (spriteBounds2.Width / 2);
            float collisionDistanceY = (spriteBounds1.Height / 2) + (spriteBounds2.Height / 2);

            // Check for overlap on BOTH axes
            return xDistance <= collisionDistanceX && yDistance <= collisionDistanceY;
        }

        // Fires a projectile with the given position and velocity
        public void FireProjectile(Vector2 position, Vector2 velocity, ProjectileType projectileType)
        {
            // Create the image for the projectile
            Texture2D projectileImage;
            
            if (projectileType == ProjectileType.Player)
            {
                // This is a projectile sent from the player, set it to the proper sprite
                projectileImage = playerProjectileSprite;
            }
            else
            {
                // This is a projectile sent from the enemy, set it to the proper sprite
                projectileImage = enemyProjectileSprite;
            }

            // Create the new projectile
            Projectile firedProjectile = new Projectile(position, velocity, projectileImage, projectileType);

            // Add the projectile to the list
            projectiles.Add(firedProjectile);
        }
    }
}
