using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Baby : Actor
    {
        private Scene _scene;
        private float _cooldownTime = 1;
        private float _sinceLastShot = 0;

        public Baby(float x, float y, Scene currentScene, string name = "Actor", string path = "") :
           base(x, y, name, path)
        {
            _scene = currentScene;
        }

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

        public override void OnCollision(Actor actor)
        {
            
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
