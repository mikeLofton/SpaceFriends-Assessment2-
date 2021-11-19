using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        /// <summary>
        /// Gets the length of the vector
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z); }
        }

        /// <summary>
        /// Gets the normalized version of this vector without changing it
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                Vector3 value = this;
                return value.Normalize();
            }
        }

        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The upwards vector
        /// </summary>
        public static Vector3 UP
        {
            get { return new Vector3(0, 1, 0); }
        }

        /// <summary>
        /// The right vector
        /// </summary>
        public static Vector3 RIGHT
        {
            get { return new Vector3(1, 0, 0); }
        }

        /// <summary>
        /// Changes this vector to have a magnitude that is equal to one
        /// </summary>
        /// <returns>The result of the normalization. Returns an empty vector if the magnitude is zero</returns>
        public Vector3 Normalize()
        {
            if (Magnitude == 0)
                return new Vector3();

            return this /= Magnitude;
        }

        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The dot product of the first vector on to the second</returns>
        public static float DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z);
        }

        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The cross product of the two vectors</returns>
        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3
                (
                    (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                    (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                    (lhs.X * rhs.Y) - (lhs.Y * rhs.X)
                );
        }

        /// <summary>
        /// Finds the distance from the first vector to the second
        /// </summary>
        /// <param name="lhs">The starting point</param>
        /// <param name="rhs">The ending point</param>
        /// <returns>A scalar representing the distance</returns>
        public static float Distance(Vector3 lhs, Vector3 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Subtracts the x value of the second vector to the first, subtracts the y value of the second vector to the first, and subtracts the z value of the second vector to the first
        /// </summary>
        /// <param name="lhs">The vector that is being subtracted from</param>
        /// <param name="rhs">The vector used to subtract from the 1st vector</param>
        /// <returns>The result of the vector subtraction</returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z };
        }

        /// <summary>
        /// Adds the x value of the second vector to the first, adds the y value of the second vector to the first, and adds the z value of the second vector to the first
        /// </summary>
        /// <param name="lhs">The vector that is increasing</param>
        /// <param name="rhs">The vector used to increase the 1st vector</param>
        /// <returns>The result of the vector addition</returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z };
        }

        /// <summary>
        /// Multiplies the vectors x, y, and z values by the scalar
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="rhs">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            Vector3 result = new Vector3();

            result.X = lhs.X *= rhs;
            result.Y = lhs.Y *= rhs;
            result.Z = lhs.Z *= rhs;

            return result;
        }

        /// <summary>
        /// Multiplies the vectors x, y, and z values by the scalar
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="rhs">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            Vector3 result = new Vector3();

            result.X = rhs.X *= lhs;
            result.Y = rhs.Y *= lhs;
            result.Z = rhs.Z *= lhs;

            return result;
        }

        /// <summary>
        /// Divides the vector's x, y, and z values by the scalar given
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="rhs">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            Vector3 result = new Vector3();

            result.X = lhs.X /= rhs;
            result.Y = lhs.Y /= rhs;
            result.Z = lhs.Z /= rhs;

            return result;
        }

        /// <summary>
        /// Compares the x, y, and z values of two vectors
        /// </summary>
        /// <param name="lhs">The left side of the comparison</param>
        /// <param name="rhs">The right side of the comparison</param>
        /// <returns>True if the x, y, and z values of both vectors match</returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the x, y, and z values of two vectors
        /// </summary>
        /// <param name="lhs">The left side of the comparison</param>
        /// <param name="rhs">The right side of the comparison</param>
        /// <returns>True if the x, y, or z values of both vectors don't match</returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z)
            {
                return true;
            }

            return false;
        }
    }
}
