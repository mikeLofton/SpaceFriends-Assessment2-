using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    public struct Vector4
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        /// <summary>
        /// Gets the length of the vector
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W); }
        }

        /// <summary>
        /// Gets the normalized version of this vector without changing it
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                Vector4 value = this;
                return value.Normalize();
            }
        }

        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        /// <param name="w">w value</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Changes this vector to have a magnitude that is equal to one
        /// </summary>
        /// <returns>The result of the normalization. Returns an empty vector if the magnitude is zero</returns>
        public Vector4 Normalize()
        {
            if (Magnitude == 0)
                return new Vector4();

            return this /= Magnitude;
        }

        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The dot product of the first vector on to the second</returns>
        public static float DotProduct(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.X * rhs.X) + (lhs.Y * rhs.Y) + (lhs.Z * rhs.Z) + (lhs.W * rhs.W);
        }

        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>A new vector thats perendicular to the lhs and rhs vectors</returns>
        public static Vector4 CrossProduct(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4
                (
                    (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                    (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                    (lhs.X * rhs.Y) - (lhs.Y * rhs.X),
                    0
                );
        }

        /// <summary>
        /// Finds the distance from the first vector to the second
        /// </summary>
        /// <param name="lhs">The starting point</param>
        /// <param name="rhs">The ending point</param>
        /// <returns>A scalar representing the distance</returns>
        public static float Distance(Vector4 lhs, Vector4 rhs)
        {
            return (rhs - lhs).Magnitude;
        }

        /// <summary>
        /// Subtracts the x, y, z, and w value of the second vector to the values of the first
        /// </summary>
        /// <param name="lhs">The vector that is being subtracted from</param>
        /// <param name="rhs">The vector used to subtract from the 1st vector</param>
        /// <returns>The result of the vector subtraction</returns>
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y, Z = lhs.Z - rhs.Z, W = lhs.W - rhs.W };
        }

        /// <summary>
        /// Adds the x, y, z, and w value of the second vector to the values of the first
        /// </summary>
        /// <param name="lhs">The vector that is increasing</param>
        /// <param name="rhs">The vector being added the 1st vector</param>
        /// <returns>The result of the vector addition</returns>
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y, Z = lhs.Z + rhs.Z, W = lhs.W + rhs.W };
        }

        /// <summary>
        /// Multiplies the vectors x, y, z, and w values by the scalar
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="rhs">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            Vector4 result = new Vector4();

            result.X = lhs.X *= rhs;
            result.Y = lhs.Y *= rhs;
            result.Z = lhs.Z *= rhs;
            result.W = lhs.W *= rhs;

            return result;
        }

        /// <summary>
        /// Multiplies the vectors x, y, z, and w values by the scalar
        /// </summary>
        /// <param name="lhs">The value to scale the vector by</param>
        /// <param name="rhs">The vector that is being scaled</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            Vector4 result = new Vector4();

            result.X = rhs.X *= lhs;
            result.Y = rhs.Y *= lhs;
            result.Z = rhs.Z *= lhs;
            result.W = rhs.W *= lhs;

            return result;
        }

        /// <summary>
        /// Divides the vector's x, y, z, and w values by the scalar given
        /// </summary>
        /// <param name="lhs">The vector that is being scaled</param>
        /// <param name="rhs">The value to scale the vector by</param>
        /// <returns>The result of the vector scaling</returns>
        public static Vector4 operator /(Vector4 lhs, float rhs)
        {
            Vector4 result = new Vector4();

            result.X = lhs.X /= rhs;
            result.Y = lhs.Y /= rhs;
            result.Z = lhs.Z /= rhs;
            result.W = lhs.W /= rhs;

            return result;
        }

        /// <summary>
        /// Compares the x, y, z, and w values of two vectors
        /// </summary>
        /// <param name="lhs">The left side of the comparison</param>
        /// <param name="rhs">The right side of the comparison</param>
        /// <returns>True if the x, y, z and w values of both vectors match</returns>
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z && lhs.W == rhs.W)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the x, y, z, and w values of two vectors
        /// </summary>
        /// <param name="lhs">The left side of the comparison</param>
        /// <param name="rhs">The right side of the comparison</param>
        /// <returns>True if the x, y, z, or w values of both vectors don't match</returns>
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            if (lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z || lhs.W != rhs.W)
            {
                return true;
            }

            return false;
        }
    }
}
