using Microsoft.Xna.Framework;

namespace ArcadeFlyer2D
{
    // Timer mechanism class
    class Timer
    {
        // Total amount of time (in seconds) for the timer
        private float totalTime;

        // Current amount of time on the timer
        private float timer;
        
        // Is the timer currently active?
        public bool Active { get; private set; }
        
        // Initialize a Timer object
        public Timer(float totalTime)
        {
            // Initialize values
            this.totalTime = totalTime;
            this.timer = 0.0f;
            this.Active = false;
        }

        // Kick off a timer process process
        public void StartTimer()
        {
            Active = true;
            timer = 0.0f;
        }

        // Update the timer based on the time that has passed
        public void Update(GameTime gameTime)
        {
            // If the timer is currently active...
            if (Active)
            {
                // Increment the timer
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // If all the time has elapsed...
                if (timer >= totalTime)
                {
                    // Timer has completed!
                    Active = false;
                }
            }
        }
    }
}