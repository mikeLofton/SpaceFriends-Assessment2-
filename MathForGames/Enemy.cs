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
        private float _cooldownTime = 25;
        private float _sinceLastShark = 0;
        private float _sinceLastClam = 0;       

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

        public Enemy(float x, float y, float speed, float type, Actor target, string name = "Actor", string path = "") :
            base(x, y, name, path)
        {
            _speed = speed;
            _enemyType = type;
            _target = target;           
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            Vector2 direction = new Vector2();
            float distance;

            direction = _target.LocalPosition - LocalPosition;

            direction.Normalize();

            Velocity = direction * Speed;

            distance = Vector2.Distance(_target.LocalPosition, LocalPosition);

            if (GetTargetInSight() && distance < 500)
                LocalPosition += Velocity * deltaTime;

            if (_enemyType == 1)
                LookAt(_target.WorldPosition);

            if (_enemyType == 2)
                Rotate(0.5f);
            
            base.Update(deltaTime);
        }

        public bool GetTargetInSight()
        {
            Vector2 directionOfTarget = (_target.LocalPosition - LocalPosition).Normalized;

            return Math.Acos(Vector2.DotProduct(directionOfTarget, Forward)) * (180 / Math.PI) < 360;
        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collision occurred");
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

        public override void End()
        {
            base.End();
        }
    }
}
