using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    enum ColliderType
    {
        CIRCLE,
        AABB
    }

    abstract class Collider
    {
        private Actor _owner;
        private ColliderType _colliderType;

        /// <summary>
        /// The owner of a collider
        /// </summary>
        public Actor Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// The type of collider
        /// </summary>
        public ColliderType ColliderType
        {
            get { return _colliderType; }
        }

        /// <param name="owner">The actor that owns a collider</param>
        /// <param name="colliderType">The collider type the actor owns</param>
        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        /// <summary>
        /// Checks for collision with another actor
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CheckCollison(Actor other)
        {
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                return CheckCollisionCircle((CircleCollider)other.Collider);
            else if (other.Collider.ColliderType == ColliderType.AABB)
                return CheckCollisionAABB((AABBCollider)other.Collider);

            return false;
        }

        /// <summary>
        /// Checks for collision with CircleCollider
        /// Meant to be overriden by other collider classes.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckCollisionCircle(CircleCollider other) { return false; }

        /// <summary>
        /// Checks for collision with AABBCollider
        /// Meant to be overriden by other collider classes
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckCollisionAABB(AABBCollider other) { return false; }
    }
}
