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
        private float _cooldownTime = 0.5f;
        private float _sinceLastShot = 0;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player(float x, float y, float speed, Scene currentScene, string name = "Actor", string path = "") : 
            base(x, y, name, path)
        {
            _speed = speed;
            _scene = currentScene;
        }

        public override void Update(float deltaTime)
        {
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

            if (_sinceLastShot > _cooldownTime)
            {
                if (xBulletDirection != 0 || yBulletDirection != 0)
                {
                    _scene.AddActor(bullet);
                    _sinceLastShot = 0;
                }
            }
            
            //Create a vector that stores the move input
            Vector2 moveDirection = new Vector2(xDirection, yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if (Velocity.Magnitude > 0)
                Forward = Velocity.Normalized;

            LocalPosition += Velocity;

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
