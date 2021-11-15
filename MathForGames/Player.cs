using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Scene _scene;
        //How long the player has to wait (in seconds) before firing a bullet again
        private float _cooldownTime = 1;
        //How much time has passed since since the last time the player fired a bullet
        private float _sinceLastShot = 0;      

        /// <summary>
        /// The player's speed
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// The player's velocity
        /// </summary>
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        /// <summary>
        /// The Player Constructor
        /// </summary>
        /// <param name="x">The player's x position in the world</param>
        /// <param name="y">The player's y position in the world</param>
        /// <param name="speed">The player's movement speed</param>
        /// <param name="currentScene">The scene the player is currently in</param>
        /// <param name="name">The player's name</param>
        /// <param name="path">The player's sprite</param>
        public Player(float x, float y, float speed, Scene currentScene, string name = "Actor", string path = "") : 
            base(x, y, name, path)
        {
            _speed = speed;
            _scene = currentScene;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        /// <param name="deltaTime">The amount of time between frames</param>
        public override void Update(float deltaTime)
        {
            //Adds the current delta time to _sinceLastShot
            _sinceLastShot += deltaTime;

            //Get the player input direction
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            int yDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            //The player shot direction
            int xBulletDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));

            int yBulletDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

            //Bullet's Values
            Bullet bullet = new Bullet(LocalPosition.X, LocalPosition.Y, 150, xBulletDirection, yBulletDirection, _scene, "Bullet", "Images/strawberry.png");
            bullet.SetScale(25, 25);
            CircleCollider bulletCircleCollider = new CircleCollider(15, bullet);
            bullet.Collider = bulletCircleCollider;

            //If the amount of time since last shot is greater than cooldown time
            if (_sinceLastShot > _cooldownTime)
            {
                //If the x or y bullet direction do not equal zero...
                if (xBulletDirection != 0 || yBulletDirection != 0)
                {
                    //Add bullet to the scene
                    _scene.AddActor(bullet);
                    //Set since last shot to zero
                    _sinceLastShot = 0;
                }
            }
            
            //Create a vector that stores the move input
            Vector2 moveDirection = new Vector2(xDirection, yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if (Velocity.Magnitude > 0)
                Forward = Velocity.Normalized;

            LocalPosition += Velocity;

            //Makes the player unable to go offscreen
            float resultX = Math.Clamp(LocalPosition.X, 0, 1600);
            float resultY = Math.Clamp(LocalPosition.Y, 0, 900);
            LocalPosition = new Vector2(resultX, resultY);

            base.Update(deltaTime);
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is Enemy)
                Engine.CloseApplication();
                
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
