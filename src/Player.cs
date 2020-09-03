using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcadeFlyer2D
{
    // The player, controlled by the keyboard
    class Player
    {
        // A reference to the game that will contain the player
        private ArcadeFlyerGame root;

        // The current position of the player
        private Vector2 position;

        // An image texture for the player sprite
        private Texture2D spriteImage;

        // The width of the player sprite
        private float spriteWidth;

        // The height of the player sprite
        public float SpriteHeight
        {
            get
            {
                // Calculated based on the width
                float scale = spriteWidth / spriteImage.Width;
                return spriteImage.Height * scale;
            }
        }
        
        // The properly scaled position rectangle for the player sprite
        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spriteWidth, (int)SpriteHeight);
            }
        }

        // The speed at which the player can move
        private float movementSpeed = 4.0f;

        // Initialize a player
        public Player(ArcadeFlyerGame root, Vector2 position)
        {
            // Initialize values
            this.root = root;
            this.position = position;
            this.spriteWidth = 128.0f;

            // Load the content for the player
            LoadContent();
        }

        // Loads all the assets for the player
        public void LoadContent()
        {
            // Get the MainChar image
            this.spriteImage = root.Content.Load<Texture2D>("MainChar");
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
        }

        // Draw the player
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Use the Sprite Batch to draw
            spriteBatch.Draw(spriteImage, PositionRectangle, Color.White);
        }
    }
}
