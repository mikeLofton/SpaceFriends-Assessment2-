﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        private string _name;
        private bool _started;
        private Vector2 _forward = new Vector2(1,0);
        private Collider _collider;
        private Matrix3 _globalTransform = Matrix3.Identity;
        private Matrix3 _localTransform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Actor[] _children = new Actor[0];
        private Actor _parent;
        private Sprite _sprite;

        /// <summary>
        /// True if the start functions has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public float ScaleX
        {
            get {return new Vector2(_scale.M00, _scale.M10).Magnitude; }
        }

        public float ScaleY
        {
            get { return new Vector2(_scale.M00, _scale.M10).Magnitude; }
        }

        public Vector2 LocalPosition
        {
            get { return new Vector2(_translation.M02, _translation.M12); }
            set 
            {
                SetTranslation(value.X, value.Y);
            }
        }

        public Vector2 WorldPosition
        {
            get { return new Vector2(_translation.M02, _translation.M12); }
            set 
            {
                if (Parent != null)
                {
                    Vector2 offset = value - Parent.LocalPosition;

                    SetTranslation(offset.X / ScaleX, offset.Y / ScaleY);
                }
                else
                {
                    SetTranslation(value.X, value.Y);
                }                
            }
        }

        public Matrix3 GlobalTransform
        {
            get { return _globalTransform; } 
            private set { _globalTransform = value; }
        }

        public Matrix3 LocalTransform
        {
            get { return _localTransform; }
            private set { _localTransform = value; }
        }

        public Actor Parent
        {
            get {return _parent; }
            set { _parent = value; }
        }

        public Actor[] Children
        {
            get { return _children; }
        }

        public Vector2 Size
        {
            get { return new Vector2(_scale.M00, _scale.M11); }
            set { SetScale(value.X, value.Y); }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_rotation.M00, _rotation.M10); }
            set
            {
                Vector2 point = value.Normalized + LocalPosition;
                LookAt(point);
            }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        /// <summary>
        /// The collider attached to the actor
        /// </summary>
        public Collider Collider
        {
            get { return _collider; }
            set { _collider = value; }
        }

        public Actor(float x, float y, string name = "Actor", string path = "") : 
            this(new Vector2 { X = x, Y = y}, name, path) {}

        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            LocalPosition = position;
            _name = name;

            if (path != "")
                _sprite = new Sprite(path);
        }

        public void UpdateTransforms()
        {
            if (_parent != null)
                GlobalTransform = _parent.GlobalTransform * LocalTransform;
            else
                GlobalTransform = LocalTransform;
        }

        public void AddChild(Actor child)
        {
            //Create a temp array larger than the original
            Actor[] tempArray = new Actor[_children.Length + 1];

            //Copy all values from the orginal array into the temp array
            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            //Add the new actor to the end of the new array
            tempArray[_children.Length] = child;

            //Set the old array to be the new array
            _children = tempArray;

            child.Parent = this;
        }

        public bool RemoveChild(Actor child)
        {
            //Create a variable to store if the removal was successful
            bool childRemoved = false;

            //Create a new array that is smaller than the original
            Actor[] tempArray = new Actor[_children.Length - 1];

            //Copy all values except the actor we don't want into the new array
            int j = 0;

            for (int i = 0; i < _children.Length; i++)
            {
                //If the actor that the loop is on is not the one to remove...
                if (_children[i] != child)
                {
                    //...add the actor into the new array and increment the temp array counter
                    tempArray[j] = _children[i];
                    j++;
                }
                //Otherwise if this actor is the one to remove...
                else
                {
                    //...set actorRemoved to true
                    childRemoved = true;
                }
            }

            //If actor removed is successful set actors to temp array
            if (childRemoved)
            {
                _children = tempArray;
                child.Parent = null;
            }

            return childRemoved;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            _localTransform = _translation * _rotation * _scale;
            UpdateTransforms();
            Console.WriteLine(_name + ": " + WorldPosition.X + ", " + WorldPosition.Y);
        }

        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_globalTransform);
        }

        public void End()
        {

        }

        public virtual void OnCollision(Actor actor)
        {

        }

        /// <summary>
        /// Checks if this actor collided with another actor
        /// </summary>
        /// <param name="other">The actor to check for a collision against</param>
        /// <returns>True if the distance between the actors is less than the radii of the two combined</returns>
        public virtual bool CheckForCollision(Actor other)
        {
            //Return false if either actor doesn't have a collider attached
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollison(other);
        }

        /// <summary>
        /// Sets the position of the actor
        /// </summary>
        /// <param name="translationX">The new x position</param>
        /// <param name="translationY">The new y position</param>
        public void SetTranslation(float translationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="translationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the y</param>
        public void Translate(float translationX, float translationY)
        {
            _translation *= Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Set the rotation of the actor.
        /// </summary>
        /// <param name="radians">The angle of the new rotation in radians.</param>
        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Adds a rotation to the current transform's rotation.
        /// </summary>
        /// <param name="radians">The angle in the radians to turn.</param>
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Sets the scale of the actor
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Scales the actor by the given amount
        /// </summary>
        /// <param name="x">The value to scale on the x axis.</param>
        /// <param name="y">The value to scale on the y axis</param>
        public void Scale(float x, float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }

        /// <summary>
        /// Rotates the actor to face the given position
        /// </summary>
        /// <param name="position">The position the actor should be looking towards</param>
        public void LookAt(Vector2 position)
        {
            //Find the direction the actor should look in
            Vector2 direction = (position - LocalPosition).Normalized;

            //Use the dot product to find the angle the actor needs to rotate
            float dotProd = Vector2.DotProduct(direction, Forward);

            if (dotProd > 1)
                dotProd = 1;

            float angle = (float)Math.Acos(dotProd);

            //Find the perpindicular vector to the direction
            Vector2 perpDirection = new Vector2(direction.Y, -direction.X);

            //Find the dot product of the perpindicular vector and the current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //if the result isn't 0, use it to change the sign of the angle to either be positive or negative
            if (perpDot != 0)
                angle *= -perpDot / Math.Abs(perpDot);

            Rotate(angle);
        }
    }
}
