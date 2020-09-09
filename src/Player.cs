using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    // The player, controlled by the keyboard
    class Player : Sprite
    {
        // A reference to the game that will contain the player
        private ArcadeFlyerGame root;

        // The speed at which the player can move
        private float movementSpeed = 4.0f;

        // Cool down timer for projectiles
        private Timer projectileCoolDown;

        // Initialize a player
        public Player(ArcadeFlyerGame root, Vector2 position) : base(position)
        {
            // Initialize values
            this.root = root;
            this.position = position;
            this.SpriteWidth = 128.0f;
            this.projectileCoolDown = new Timer(0.5f);

            // Load the content for the player
            LoadContent();
        }

        // Loads all the assets for the player
        public void LoadContent()
        {
            // Get the MainChar image
            this.SpriteImage = root.Content.Load<Texture2D>("MainChar");
        }

        // Update position based on input
        private void HandleInput(KeyboardState currentKeyboardState)
        {
            // Get all the key states
            bool upKeyPressed = currentKeyboardState.IsKeyDown(Keys.Up);
            bool downKeyPressed = currentKeyboardState.IsKeyDown(Keys.Down);
            bool leftKeyPressed = currentKeyboardState.IsKeyDown(Keys.Left);
            bool rightKeyPressed = currentKeyboardState.IsKeyDown(Keys.Right);

            // If Up is pressed, decrease position Y
            if (upKeyPressed)
            {
                position.Y -= movementSpeed;
            }
            
            // If Down is pressed, increase position Y
            if (downKeyPressed)
            {
                position.Y += movementSpeed;
            }
            
            // If Left is pressed, decrease position X
            if (leftKeyPressed)
            {
                position.X -= movementSpeed;
            }
            
            // If Right is pressed, increase position X
            if (rightKeyPressed)
            {
                position.X += movementSpeed;
            }
        }

        // Called each frame
        public void Update(GameTime gameTime)
        {   
            // Get current keyboard state
            KeyboardState currentKeyboardState = Keyboard.GetState();

            // Handle any movement input
            HandleInput(currentKeyboardState);

            // If able to fire projectiles and Space is pressed...
            if (!projectileCoolDown.Active && currentKeyboardState.IsKeyDown(Keys.Space))
            {
                // Generate the projectile information
                Vector2 projectilePosition = new Vector2(position.X + SpriteWidth, position.Y + SpriteHeight / 2);
                Vector2 projectileVelocity = new Vector2(10.0f, 0.0f);

                // Fire the projectile from the main game
                root.FireProjectile(projectilePosition, projectileVelocity, ProjectileType.Player);

                // Start the cool down process
                projectileCoolDown.StartTimer();
            }
            
            // Update the cool down timer
            projectileCoolDown.Update(gameTime);
        }
    }
}
