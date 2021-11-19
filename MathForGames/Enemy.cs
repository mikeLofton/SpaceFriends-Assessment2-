using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private float _enemyType;
        private Actor _target;
        private Scene _scene;      

        /// <summary>
        /// The enemy's speed
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

        /// <param name="x">The x position in the world</param>
        /// <param name="y">The y position in the world</param>
        /// <param name="speed">The enemy's speed</param>
        /// <param name="type">The enemy's type</param>
        /// <param name="target">The enemy's target</param>
        /// <param name="currentScene">The enemy's current scene</param>
        /// <param name="name">The enemy's name</param>
        /// <param name="path">The enemy's sprite</param>
        public Enemy(float x, float y, float speed, float type, Actor target, Scene currentScene, string name = "Actor", string path = "") :
            base(x, y, name, path)
        {
            _speed = speed;
            _enemyType = type;
            _target = target;
            _scene = currentScene;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            Vector2 direction = new Vector2();
            float distance;

            direction = _target.WorldPosition - WorldPosition;

            direction.Normalize();

            Velocity = direction * Speed;

            distance = Vector2.Distance(_target.WorldPosition, WorldPosition);

            if ( distance < 900)
                LocalPosition += Velocity * deltaTime;

            if (_enemyType == 1)
                LookAt(_target.WorldPosition);

            if (_enemyType == 2)
                Rotate(0.5f);
            
            base.Update(deltaTime);
        }

        /// <summary>
        /// Collision between enemy and another actor
        /// </summary>
        /// <param name="actor"></param>
        public override void OnCollision(Actor actor)
        {
            //if the actor is a baby...
            if (actor is Baby)
                //Remove the baby from the scene
                _scene.RemoveActor(actor);

            Console.WriteLine("Collision Occored");
        }

        /// <summary>
        /// Draws the enemy sprites
        /// </summary>
        public override void Draw()
        {
            base.Draw();
        }
    }
}
