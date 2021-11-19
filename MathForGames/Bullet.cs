using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Bullet : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private int _xDirection;
        private int _yDirection;
        private Scene _scene;
        //How long the bullet exists before being removed from the scene
        private float _existanceTime = 10;
        //How long has passed since the bullet was added to the scene
        private float _sinceExisting = 0;

        /// <summary>
        /// The bullet's speed
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// The bullet's velocity
        /// </summary>
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="speed"></param>
        /// <param name="bulletXDirection"></param>
        /// <param name="bulletYDirection"></param>
        /// <param name="currentScene"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public Bullet(float x, float y, float speed, int bulletXDirection, int bulletYDirection, Scene currentScene, string name = "Bullet", string path = "") :
            base(x, y, name, path)
        {
            _speed = speed;
            _xDirection = bulletXDirection;
            _yDirection = bulletYDirection;
            _scene = currentScene;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            _sinceExisting += deltaTime;

            //Vector2 that stores the move input
            Vector2 moveDirection = new Vector2(_xDirection, _yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            LocalPosition += Velocity;

            //If the bullet has existed longer than the existance time
            if (_sinceExisting > _existanceTime)
            {
                //Remove the bullet from scene
                _scene.RemoveActor(this);
                //Set existance time to zero
                _sinceExisting = 0;
            }

            base.Update(deltaTime);
        }

        /// <summary>
        /// Collision between bullet and another actor
        /// </summary>
        /// <param name="actor"></param>
        public override void OnCollision(Actor actor)
        {
            //If the other actor is an Enemy...
            if (actor is Enemy)
            {
                //Remove the enemy form the scene
                _scene.RemoveActor(actor);
                //Decrement the enemy count
                GameManager.EnemyCount--;             
            }             
        }
        
        /// <summary>
        /// Draws the bullet sprites
        /// </summary>
        public override void Draw()
        {
            base.Draw();
        }
    }
}
