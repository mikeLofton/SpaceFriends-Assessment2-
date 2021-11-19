**Michael Lofton**

s218033 

Math For Games

MathLibrary

# I. Requirements
    
 1. **Description of Problem**

    **Name:** MathLibrary

    **Problem Statement:** 
    
  

 2. **Input Information:**
    
 3. **Output Information:**
    
# II. Design
 1. *System Architecture*
 vwgrg
    
 2. *Object Information*
    * **File Name:** Vector2.cs
        * **Struct Name:** Vector2
        * Name: X(float)
            * Description: The Vector2 X value.
            * Visibility: public
        * Name: Y(float)
            * Description: The Vector2 Y value.
            * Visibility: public 
        * Name: Vector2() 
            * Description: Vector2 Constructor. Takes in an X and Y value.
            * Visibility: public 
        * Name: Magnitude(float)
            * Description: Gets the length of the vector.
            * Visibility: public
        * Name: Normalized(Vector2) 
            * Description: Gets the normalized version of this vector without changing it.
            * Visibility: public
        * Name: Normalize()
            * Description: Changes this vector to have a magnitude that is equal to one. Returns the result of the normalization.
            * Visibility: public
        * Name: DotProduct(Vector2 lhs, Vector2 rhs)
            * Description: Returns the dot product of the first vector on to the second.
            * Visibility: public
            * Type: static float    
        * Name: Distance(Vector2 lhs, Vector2 rhs)
            * Description: Finds the distance from the first vector to the second.
            * Visibility: public
            * Type: static float 
        * Name: +(Vector2 lhs, Vector2 rhs)
            * Description: Adds the x value of the second vector to the first, and adds the y value of the second vector to the first.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: -(Vector2 lhs, Vector2 rhs)
            * Description: Subtracts the x value of the second vector to the first, and subtracts the y value of the second vector to the first.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: *(Vector2 lhs, float rhs)
            * Description: Multiplies the vectors x and y values by the scalar.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: /(Vector2 lhs, float rhs)
            * Description: Divides the vector's x and y values by the scalar.
            * Visibility: public
            * Type: static Vector2 operator
        * Name: ==(Vector2 lhs, Vector2 rhs)
            * Description: Compares the x and y values of two vectors. Returns true if the x and y values of both vectors match.
            * Visibility: public
            * Type: static bool operator
        * Name: !=(Vector2 lhs, Vector2 rhs)
            * Description: Compares the x and y values of two vectors. True if the x values of both vectors don't match and the y values don't match. 
            * Visibility: public 
            * Type: static bool operator
    * **File Name:** Vector3.cs
        * **Struct Name:** Vector3
        * Name: X(float)
            * Description: The Vector3 X value.
            * Visibility: public
        * Name: Y(float)
            * Description: The Vector3 Y value.
            * Visibility: public 
        * Name: Z(float)
            * Description: The Vector3 Z value.
            * Visibility: public
        * Name: Magnitude(float)
            * Description: Gets the length of the vector.
            * Visibility: public
        * Name: Normalized(Vector3) 
            * Description: Gets the normalized version of this vector without changing it.
            * Visibility: public
        * Name: Vector3()
            * Description: Vector3 constructor. Takes in x, y, and z values.
            * Visibility: public
        * Name: UP(static Vector3)
            * Description: The upwards vector.
            * Visibility: public
        * Name: RIGHT(static Vector3)
            * Description: The right vector.
            * Visibility: public
        * Name: Normalize()
            * Description: Changes this vector to have a magnitude that is equal to one. Returns the result of the normalization.
            * Visibility: public
            * Type: Vector3
        * Name: DotProduct(Vector3 lhs, Vector3 rhs)
            * Description: Returns the dot product of the first vector on to the second.
            * Visibility: public
            * Type: static float 
        * Name: CrossProduct(Vector3 lhs, Vector3 rhs)
            * Description: Returns the cross product of the two vectors.
            * Visibility: public
            * Type: static Vector3   
        * Name: Distance(Vector3 lhs, Vector3 rhs)
            * Description: Finds the distance from the first vector to the second.
            * Visibility: public
            * Type: static float 
        * Name: -(Vector3 lhs, Vector3 rhs)
            * Description: Subtracts the x value of the second vector to the first, subtracts the y value of the second vector to the first, and subtracts the z value of the second vector to the first.
            * Visibility: public
            * Type: static Vector3 operator
        * Name: +(Vector3 lhs, Vector3 rhs)
            * Description: Adds the x value of the second vector to the first, adds the y value of the second vector to the first, and adds the z value of the second vector to the first.
            * Visibility: public
            * Type: static Vector3 operator       
        * Name: *(Vector3 lhs, float rhs)
            * Description: Multiplies the vectors x, y, and z values by the scalar.
            * Visibility: public
            * Type: static Vector3 operator
        * Name: *(float lhs, Vector3 rhs)
            * Description: Multiplies the vectors x, y, and z values by the scalar.
            * Visibility: public
            * Type: static Vector3 operator
        * Name: /(Vector3 lhs, float rhs)
            * Description: Divides the vector's x, y, and z values by the scalar given
            * Visibility: public
            * Type: static Vector3 operator
        * Name: ==(Vector3 lhs, Vector3 rhs)
            * Description: Compares the x, y, and z values of two vectors. Returns true if the x, y, and z values of both vectors match
            * Visibility: public
            * Type: static bool operator
        * Name: !=(Vector3 lhs, Vector3 rhs)
            * Description: Compares the x, y, and z values of two vectors. Returns true if the x, y, or z values of both vectors don't match 
            * Visibility: public 
            * Type: static bool operator
    * **File Name:** Vector4.cs
        * **Struct Name:** Vector4
        * Name: X(float)
            * Description: The Vector4 X value.
            * Visibility: public
        * Name: Y(float)
            * Description: The Vector4 Y value.
            * Visibility: public 
        * Name: Z(float)
            * Description: The Vector4 Z value.
            * Visibility: public
        * Name: W(float)
            * Description: The Vector4 W value.
            * Visibility: public
        * Name: Magnitude(float)
            * Description: Gets the length of the vector.
            * Visibility: public
        * Name: Normalized(Vector4) 
            * Description: Gets the normalized version of this vector without changing it.
            * Visibility: public
        * Name: Vector4()
            * Description: Vector4 constructor. Takes in x, y, z, and w values.
            * Visibility: public
        * Name: Normalize()
            * Description: Changes this vector to have a magnitude that is equal to one. Returns the result of the normalization.
            * Visibility: public
            * Type: Vector4
        * Name: DotProduct(Vector4 lhs, Vector4 rhs)
            * Description: Returns the dot product of the first vector on to the second.
            * Visibility: public
            * Type: static float 
        * Name: CrossProduct(Vector4 lhs, Vector4 rhs)
            * Description: Returns the cross product of the two vectors.
            * Visibility: public
            * Type: static Vector4   
        * Name: Distance(Vector4 lhs, Vector4 rhs)
            * Description: Finds the distance from the first vector to the second.
            * Visibility: public
            * Type: static float 
        * Name: -(Vector4 lhs, Vector4 rhs)
            * Description: Subtracts the x, y, z, and w value of the second vector to the values of the first.
            * Visibility: public
            * Type: static Vector4 operator
        * Name: +(Vector4 lhs, Vector4 rhs)
            * Description: Adds the x, y, z, and w value of the second vector to the values of the first
            * Visibility: public
            * Type: static Vector4 operator       
        * Name: *(Vector4 lhs, float rhs)
            * Description: Multiplies the vectors x, y, z, and w values by the scalar
            * Visibility: public
            * Type: static Vector4 operator
        * Name: *(float lhs, Vector4 rhs)
            * Description: Multiplies the vectors x, y, z, and w values by the scalar
            * Visibility: public
            * Type: static Vector4 operator
        * Name: /(Vector4 lhs, float rhs)
            * Description:  Divides the vector's x, y, z, and w values by the scalar given
            * Visibility: public
            * Type: static Vector4 operator
        * Name: ==(Vector4 lhs, Vector4 rhs)
            * Description: Compares the x, y, z, and w values of two vectors. Returns true if the x, y, z and w values of both vectors match.
            * Visibility: public
            * Type: static bool operator
        * Name: !=(Vector4 lhs, Vector4 rhs)
            * Description: Compares the x, y, z, and w values of two vectors. Returns true if the x, y, z, or w values of both vectors don't match.
            * Visibility: public 
            * Type: static bool operator
    * **File Name:** Matrix3.cs
        * **Struct Name:** Matrix3
        * Name: Matrix3()
            * Description: Takes in the rows and columns of the matrix3.
            * Visibility: public
        * Name: Identity(static Matrix3)
            * Description: Creates an Identity Matrix3.
            * Visibility: public
        * Name: CreateRotation(float radians)
            * Description: Creates a new matrix that has been rotated by the given value in radians.
            * Visibility: public 
            * Type: static Matrix3
        * Name: CreateTranslation(float x, float y)
            * Description: Creates a new matrix that has been translated by the given x and y value.
            * Visibility: public
            * Type: static Matrix3
         * Name: CreateTranslation(Vector2 position)
            * Description: Creates a new matrix that has been translated by the given Vector2.
            * Visibility: public
            * Type: static Matrix3
         * Name: CreateScale(float x, float y)
            * Description: Creates a new matrix that has been scaled by the given value.
            * Visibility: public
            * Type: static Matrix3
         * Name: +(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 addition.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: -(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 subtraction.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: *(Matrix3 lhs, Matrix3 rhs)
            * Description: Overload for matrix3 multiplication.
            * Visibility: public
            * Type: static Matrix3 operator
         * Name: *(Matrix3 lhs, Vector3 rhs)
            * Description: Overload for multiplying a matrix3 with a vector3.
            * Visibility: public
            * Type: static Vector3 operator
    * **File Name:** Matrix4.cs
        * **Struct Name:** Matrix4
        * Name: Matrix4()
            * Description: Takes in the rows and columns of the matrix4.
            * Visibility: public
        * Name: Identity(static Matrix4)
            * Description: Creates an Identity Matrix4.
            * Visibility: public
        * Name: CreateRotationZ(float radians)
            * Description: Creates a new matrix that has been rotated on the z-axis by the given value in radians.
            * Visibility: public 
            * Type: static Matrix4
        * Name: CreateRotationY(float radians)
            * Description: Creates a new matrix that has been rotated on the y-axis by the given value in radians.
            * Visibility: public 
            * Type: static Matrix4
        * Name: CreateRotationX(float radians)
            * Description: Creates a new matrix that has been rotated on the x-axis by the given value in radians.
            * Visibility: public 
            * Type: static Matrix4
        * Name: CreateTranslation(float x, float y, float z)
            * Description: Creates a new matrix that has been translated by the given x, y, and z value.
            * Visibility: public
            * Type: static Matrix4
         * Name: CreateScale(float x, float y, float z)
            * Description: Creates a new matrix that has been scaled by the given value.
            * Visibility: public
            * Type: static Matrix4
         * Name: +(Matrix4 lhs, Matrix4 rhs)
            * Description: Overload for matrix4 addition.
            * Visibility: public
            * Type: static Matrix4 operator
         * Name: -(Matrix4 lhs, Matrix4 rhs)
            * Description: Overload for matrix4 subtraction.
            * Visibility: public
            * Type: static Matrix4 operator
         * Name: *(Matrix4 lhs, Matrix4 rhs)
            * Description: Overload for matrix4 multiplication.
            * Visibility: public
            * Type: static Matrix4 operator
         * Name: *(Matrix3 lhs, Vector3 rhs)
            * Description: Overload for multiplying a matrix4 with a vector4.
            * Visibility: public
            * Type: static Vector4 operator