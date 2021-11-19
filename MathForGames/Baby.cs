using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Baby : Actor
    {
        private Scene _scene;
        //How long the player has to wait (in seconds) before firing a bullet again
        private float _cooldownTime = 1;
        //How much time has passed since the last time the player fired a bullet
        private float _sinceLastShot = 0;

        /// <param name="x">The x position in the world</param>
        /// <param name="y">The y position in the world</param>
        /// <param name="currentScene">The current scene</param>
        /// <param name="name">The baby's name</param>
        /// <param name="path">The baby's sprite path</param>
        public Baby(float x, float y, Scene currentScene, string name = "Actor", string path = "") :
           base(x, y, name, path)
        {
            _scene = currentScene;
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            _sinceLastShot += deltaTime;

            int xBulletDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
               + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT));

            int yBulletDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN));

            //Bullet's Values
            Bullet childBullet = new Bullet(WorldPosition.X, WorldPosition.Y, 150, xBulletDirection, yBulletDirection, _scene, "Bullet", "Images/watermelon.png");
            childBullet.SetScale(25, 25);
            CircleCollider childBulletCircleCollider = new CircleCollider(15, childBullet);
            childBullet.Collider = childBulletCircleCollider;

            if (_sinceLastShot > _cooldownTime)
            {
                if (xBulletDirection != 0 || yBulletDirection != 0)
                {
                    _scene.AddActor(childBullet);
                    _sinceLastShot = 0;
                }
            }

            base.Update(deltaTime);
        }

        /// <summary>
        /// Collision between Baby and another actor
        /// </summary>
        /// <param name="actor"></param>
        public override void OnCollision(Actor actor)
        {         
        }

        /// <summary>
        /// Draws the baby sprite
        /// </summary>
        public override void Draw()
        {
            base.Draw();
        }
    }
}
