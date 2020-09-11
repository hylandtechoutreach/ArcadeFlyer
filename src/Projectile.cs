using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcadeFlyer2D
{
    // A thrown object
    class Projectile : Sprite
    {
        // The current velocity of the projectile
        private Vector2 velocity;

        // The type for this projectile
        private ProjectileType projectileType;
        public ProjectileType ProjectileType
        {
            get { return projectileType; }
            set { projectileType = value; }
        }

        // Initialize a projectile
        public Projectile(Vector2 position, Vector2 velocity, Texture2D spriteImage, ProjectileType projectileType) : base(position)
        {
            // Initialize values
            this.velocity = velocity;
            this.SpriteWidth = 32.0f;
            this.SpriteImage = spriteImage;
            this.projectileType = projectileType;
        }

        // Called each frame
        public void Update()
        {
            // Update position based on velocity
            position += velocity;
        }
    }
}