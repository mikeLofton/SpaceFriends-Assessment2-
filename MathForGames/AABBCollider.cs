using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;

        /// <summary>
        /// The size if this collider on the x axis
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// The size if this collider on the y axis
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// The farthest left x position of this collider
        /// </summary>
        public float Left
        {
            get
            {
                return Owner.WorldPosition.X - (Width / 2);
            }
        }

        /// <summary>
        /// The farthest right x position of this collider
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.WorldPosition.X + (Width / 2);
            }
        }

        /// <summary>
        /// The farthest y position upwards
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.WorldPosition.Y - (Height / 2);
            }
        }

        /// <summary>
        /// The farthest y position downwards
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.WorldPosition.Y + (Height / 2);
            }
        }

        /// <summary>
        /// AABB Constructpr
        /// </summary>
        /// <param name="width">The hitbox width</param>
        /// <param name="height">The hitbox height</param>
        /// <param name="owner">The hitbox owner</param>
        public AABBCollider(float width, float height, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = height;
        }

        /// <summary>
        /// Checks for collision between 2 AABB Colliders
        /// </summary>
        /// <param name="other">The other actor's AABB collider</param>
        /// <returns></returns>
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Return false if this owner is checking for collision against itself
            if (other.Owner == Owner)
                return false;

            //Return true if there is an overlap between boxes
            if (other.Left <= Right &&
                other.Top <= Bottom &&
                Left <= other.Right &&
                Top <= other.Bottom)
            {
                return true;
            }

            //Return false if there is no overlap
            return false;
        }

        /// <summary>
        /// Checks for collison between AABB and Circle Collider
        /// </summary>
        /// <param name="other">The other actor's Circle collider</param>
        /// <returns></returns>
        public override bool CheckCollisionCircle(CircleCollider other)
        {
            return other.CheckCollisionAABB(this);
        }
    }
}
