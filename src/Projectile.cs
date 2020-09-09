using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // A thrown object
    class Projectile : Sprite
    {
        // The current velocity of the projectile
        private Vector2 velocity;

        // Initialize a projectile
        public Projectile(Vector2 position, Vector2 velocity, Texture2D spriteImage) : base(position)
        {
            // Initialize values
            this.velocity = velocity;
            this.SpriteWidth = 32.0f;
            this.SpriteImage = spriteImage;
        }

        // Called each frame
        public void Update()
        {
            // Update position based on velocity
            position += velocity;
        }
    }
}