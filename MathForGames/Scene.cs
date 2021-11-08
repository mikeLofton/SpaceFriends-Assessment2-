﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        /// <summary>
        /// Array that contain all actors in the scene.
        /// </summary>
        private Actor[] _actors;
        private Actor[] _UIElements;

        public Scene()
        {
            _actors = new Actor[0];
            _UIElements = new Actor[0];
        }

        /// <summary>
        /// Calls start for all actors in the actors array
        /// </summary>
        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        /// <summary>
        /// Calls update for every actor in the scene. 
        /// Calls start for actor if it hasn't been called.
        /// </summary>
        public virtual void Update()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                    _actors[i].Start();

                _actors[i].Update();

                //Check for collision
                for (int j = 0; j < _actors.Length; j++)
                {
                    if (_actors[i].Position == _actors[j].Position && j != i)
                        _actors[i].OnCollision(_actors[j]);                  
                }
            }
        }

        public virtual void UpdateUI()
        {
            for (int i = 0; i < _UIElements.Length; i++)
            {
                if (!_UIElements[i].Started)
                    _UIElements[i].Start();

                _UIElements[i].Update();

                //Check for collision
                for (int j = 0; j < _UIElements.Length; j++)
                {
                    if (_UIElements[i].Position == _UIElements[j].Position && j != i)
                        _UIElements[i].OnCollision(_UIElements[j]);
                }
            }
        }

        /// <summary>
        /// Calls draw for every actor in the array
        /// </summary>
        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void DrawUI()
        {
            for (int i = 0; i < _UIElements.Length; i++)
            {
                _UIElements[i].Draw();
            }
        }

        /// <summary>
        /// Calls end for every actor in the array
        /// </summary>
        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }

        /// <summary>
        /// Adds actor to a scene
        /// </summary>
        /// <param name="actor">The actor to add</param>
        public virtual void AddActor(Actor actor)
        {
            //Create a temp array larger than the original
            Actor[] tempArray = new Actor[_actors.Length + 1];

            //Copy all values from the orginal array into the temp array
            for (int i = 0; i < _actors.Length; i++)
            {
                tempArray[i] = _actors[i];
            }

            //Add the new actor to the end of the new array
            tempArray[_actors.Length] = actor;

            //Set the old array to be the new array
            _actors = tempArray;
        }

        /// <summary>
        /// Removes the actor from the scene
        /// </summary>
        /// <param name="actor">The actor to remove</param>
        /// <returns>False if the actor was not in the scene array</returns>
        public virtual bool RemoveActor(Actor actor)
        {
            //Create a variable to store if the removal was successful
            bool actorRemoved = false;

            //Create a new array that is smaller than the original
            Actor[] tempArray = new Actor[_actors.Length - 1];

            //Copy all values except the actor we don't want into the new array
            int j = 0;

            for (int i = 0; i < tempArray.Length; i++)
            {
                //If the actor that the loop is on is not the one to remove...
                if (_actors[i] != actor)
                {
                    //...add the actor into the new array and increment the temp array counter
                    tempArray[j] = _actors[i];
                    j++;
                }
                //Otherwise if this actor is the one to remove...
                else
                {
                    //...set actorRemoved to true
                    actorRemoved = true;
                }
            }

            //If actor removed is successful set actors to temp array
            if (actorRemoved)
            {
               _actors = tempArray;
            }

            return actorRemoved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UI"></param>
        public virtual void AddUIElement(Actor UI)
        {
            //Create a temp array larger than the original
            Actor[] tempArray = new Actor[_UIElements.Length + 1];

            //Copy all values from the orginal array into the temp array
            for (int i = 0; i < _UIElements.Length; i++)
            {
                tempArray[i] = _UIElements[i];
            }

            //Add the new actor to the end of the new array
            tempArray[_UIElements.Length] = UI;

            //Set the old array to be the new array
            _UIElements = tempArray;
        }

        public virtual bool RemoveUIElement(Actor UI)
        {
            //Create a variable to store if the removal was successful
            bool uiRemoved = false;

            //Create a new array that is smaller than the original
            Actor[] tempArray = new Actor[_UIElements.Length - 1];

            //Copy all values except the actor we don't want into the new array
            int j = 0;

            for (int i = 0; i < tempArray.Length; i++)
            {
                //If the actor that the loop is on is not the one to remove...
                if (_UIElements[i] != UI)
                {
                    //...add the actor into the new array and increment the temp array counter
                    tempArray[j] = _UIElements[i];
                    j++;
                }
                //Otherwise if this actor is the one to remove...
                else
                {
                    //...set actorRemoved to true
                    uiRemoved = true;
                }
            }

            //If actor removed is successful set actors to temp array
            if (uiRemoved)
            {
                _actors = tempArray;
            }

            return uiRemoved;
        }
    }
}
