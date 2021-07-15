using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Skypex.ExtensionMethods
{
    public static class BoolE
    {
        /// <summary>
        /// Turn a bool to an int.
        /// </summary>
        /// <returns>0 for false. 1 for true.</returns>
        public static int ToInt(this bool value) => value ? 0 : 1;
    }

    /// <summary>
    /// Extension Methods used on integers.
    /// </summary>
    public static class IntE
    {
        /// <summary>
        /// Turn an int into a bool.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <returns>True if the value is 1, false if the value is 0, false with an error message otherwise.</returns>
        public static bool ToBool(this int value)
        {
            switch (value)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    Debug.LogError("A value of " + value + " cannot be converted to bool. Returning true by default.");
                    return true;
            }
        }

        /// <summary>
        /// Randomly changes the value to a positive or negative value.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <param name="negativeProbability">Probability factor.</param>
        /// <returns>Positive or negative value based on a probability factor.</returns>
        public static int WithRandomSign(this int value, float negativeProbability = 0.5f) =>
            Random.value < negativeProbability ? -value : value;

        /// <summary>
        /// Clamps minimum to given value.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <param name="min">Minimum.</param>
        /// <returns>Whichever is greater between value and min.</returns>
        public static int Min(this int value, int min) =>
            Mathf.Max(value, min);

        /// <summary>
        /// Clamps maximum to given value.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <param name="min">Maximum.</param>
        /// <returns>Whichever is lesser between value and max.</returns>
        public static int Max(this int value, int max) =>
            Mathf.Min(value, max);

        /// <summary>
        /// Clamps minimum and maximum to given value.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Maximum.</param>
        /// <returns>Clamped value between min and max</returns>
        public static int MinMax(this int value, int min, int max)
        {
            value = Mathf.Max(value, min);
            value = Mathf.Min(value, max);
            return value;
        }

        /// <summary>
        /// Checks if value is negative.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <returns>True if value is negative.</returns>
        public static bool IsNegative(this int value)
        {
            if (value < 0) 
                return true;
            return false;
        }

        /// <summary>
        /// Checks if value is zero.
        /// </summary>
        /// <param name="value">Integer.</param>
        /// <returns>True if value is zero.</returns>
        public static bool IsZero(this int value)
        {
            if (value == 0)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Extension Methods used on floats.
    /// </summary>
    public static class FloatE
    {
        /// <summary>
        /// Turn a float into a bool.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <returns>True if the value is 1, false if the value is 0, false with an error message otherwise.</returns>
        public static bool ToBool(this float value)
        {
            switch (value)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    Debug.LogError("A value of " + value + " cannot be converted to bool. Returning false by default.");
                    return false;
            }
        }

        /// <summary>
        /// Remaps a linear range to another linear range.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="valueRangeMin">Minimum value of starting range.</param>
        /// <param name="valueRangeMax">Maximum value of starting range.</param>
        /// <param name="newRangeMin">Minimum value of desired range.</param>
        /// <param name="newRangeMax">Maximum value of desired range.</param>
        /// <returns>Float altered by the remapped range.</returns>
        public static float MapRange(this float value, float valueRangeMin, float valueRangeMax, float newRangeMin, float newRangeMax) =>
            (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;

        /// <summary>
        /// Rounds the float value.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <returns>Rounded float value.</returns>
        public static float Round(this float value) =>
            Mathf.Round(value);

        /// <summary>
        /// Rounds to a multiple of a given value.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="multiple">Multiple to round to.</param>
        /// <returns>Value rounded to multiple.</returns>
        public static float Round(this float value, float multiple) =>
            (value / multiple).Round() * multiple;

        /// <summary>
        /// Clamps minimum to given value.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="min">Minimum.</param>
        /// <returns>Whichever is greater between value and min.</returns>
        public static float Min(this float value, float min) =>
            Mathf.Max(value, min);

        /// <summary>
        /// Clamps maximum to given value.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="min">Maximum.</param>
        /// <returns>Whichever is lesser between value and max.</returns>
        public static float Max(this float value, float max) =>
            Mathf.Min(value, max);

        /// <summary>
        /// Clamps minimum and maximum to given value.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Maximum.</param>
        /// <returns>Clamped value between min and max</returns>
        public static float MinMax(this float value, float min, float max)
        {
            value = Mathf.Max(value, min);
            value = Mathf.Min(value, max);
            return value;
        }

        /// <summary>
        /// Converts a Radian to a Vector2.
        /// </summary>
        /// <param name="radian">Radian.</param>
        /// <returns>Vector2 representation of a radian.</returns>
        public static Vector2 RadianToVector2(this float radian) =>
            new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));

        /// <summary>
        /// Converts a Degree to a Vector 2.
        /// </summary>
        /// <param name="degree">Degree.</param>
        /// <returns>Vector2 representation of a degree.</returns>
        public static Vector2 DegreeToVector2(this float degree) =>
            RadianToVector2(degree * Mathf.Deg2Rad);

        /// <summary>
        /// Checks if value is negative.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <returns>True if value is negative.</returns>
        public static bool IsNegative(this float value)
        {
            if (value < 0)
                return true;
            return false;
        }

        /// <summary>
        /// Checks if value is zero.
        /// </summary>
        /// <param name="value">Float.</param>
        /// <returns>True if value is zero.</returns>
        public static bool IsZero(this float value)
        {
            if (value == 0)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Extension Methods used on Vector2.
    /// </summary>
    public static class Vector2E
    {
        /// <summary>
        /// Set x and/or y to any value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <returns>Vector2 with changed values.</returns>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(x ?? vector.x, y ?? vector.y);

        /// <summary>
        /// Add any value to x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <returns>Vector2 with added values.</returns>
        public static Vector2 Add(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x + x ?? vector.x, vector.y + y ?? vector.y);

        /// <summary>
        /// Subtract any value from x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector2 Subtract(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x - x ?? vector.x, vector.y - y ?? vector.y);

        /// <summary>
        /// Multiplied any value with x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to multiply with x. (Optional)</param>
        /// <param name="y">Value to multiply with y. (Optional)</param>
        /// <returns>Vector2 with multiplied values.</returns>
        public static Vector2 Multiply(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x * x ?? vector.x, vector.y * y ?? vector.y);

        /// <summary>
        /// Divide any value with x and/or y.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to divide with x. (Optional)</param>
        /// <param name="y">Value to divide with y. (Optional)</param>
        /// <returns>Vector2 with divided values.</returns>
        public static Vector2 Divide(this Vector2 vector, float? x = null, float? y = null) =>
            new Vector2(vector.x / x ?? vector.x, vector.y / y ?? vector.y);

        /// <summary>
        /// Flatten the vector to a given value on the y axis.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="flatLevel">Value to set y to. (Default = 0)</param>
        /// <returns>Vector2 with y set to 0 or set flat level.</returns>
        public static Vector2 Flat(this Vector2 vector, float flatLevel = 0f) =>
            new Vector2(vector.x, flatLevel);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector2.</returns>
        public static Vector2 DirectionTo2D(this Vector2 source, Vector2 destination) =>
            Vector3.Normalize(destination - source);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Transform.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector2.</returns>
        public static Vector2 DirectionTo2D(this Transform source, Vector2 destination) =>
            Vector3.Normalize(destination - new Vector2(source.position.x, source.position.y));

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector.</param>
        /// <param name="destination">Transform to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector2.</returns>
        public static Vector2 DirectionTo2D(this Vector2 source, Transform destination) =>
            Vector3.Normalize(new Vector2(destination.position.x, destination.position.y) - source);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Transform.</param>
        /// <param name="destination">Transform to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector2.</returns>
        public static Vector2 DirectionTo2D(this Transform source, Transform destination) =>
            Vector3.Normalize(destination.position - source.position);

        /// <summary>
        /// Rounds each axis of the vector to a whole number.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 rounded to whole numbers.</returns>
        public static Vector2 Round(this Vector2 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            return vector;
        }

        /// <summary>
        /// Rounds each axis of the vector to a multiple of a given value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="multiple">Multiple to round to.</param>
        /// <returns>Vector2 rounded to a multiple of a number.</returns>
        public static Vector2 Round(this Vector2 vector, float multiple) =>
            (vector / multiple).Round() * multiple;

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="z">Value of z axis.</param>
        /// <returns>Vector3 found from the Vector2 and the given z value.</returns>
        public static Vector3 ToVector3(this Vector2 vector, float z) =>
            new Vector3(vector.x, vector.y, z);

        /// <summary>
        /// Converts a Vector2 to a Vector3.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="z">Value of z axis.</param>
        /// <returns>Vector3 found from the Vector2 and the given z value.</returns>
        public static Vector3 ToVector3(this Vector2 vector) =>
            new Vector3(vector.x, vector.y, 0f);

        /// <summary>
        /// Finds the closest Vector2 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector2.</param>
        /// <returns>Closest Vector2 to target.</returns>
        public static Vector2 Closest(this Vector2 target, Vector2[] vectors)
        {
            Vector2 closest = new Vector2(Mathf.Infinity, Mathf.Infinity);
            foreach (Vector2 vector in vectors)
            {
                float current = Vector2.Distance(target, vector);
                if (current < Vector2.Distance(target, closest))
                    closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Finds the farthest Vector2 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector2.</param>
        /// <returns>Farthest Vector2 from target.</returns>
        public static Vector2 Farthest(this Vector2 target, Vector2[] vectors)
        {
            Vector2 closest = Vector2.zero;
            foreach (Vector2 vector in vectors)
            {
                float current = Vector2.Distance(target, vector);
                if (current > Vector2.Distance(target, closest))
                    closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Find the average of an array of Vector2.
        /// </summary>
        /// <param name="vectors">Vector Array.</param>
        /// <returns>Average Vector2 from array.</returns>
        public static Vector2 Average(this Vector2[] vectors)
        {
            Vector2 average = Vector2.zero;
            foreach (Vector2 vector in vectors)
            {
                average += vector;
            }
            return average / vectors.Length;
        }

        /// <summary>
        /// Returns the vector with a set origin.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>Original Vector2 with new origin.</returns>
        public static Vector2 WithOrigin(this Vector2 vector, Vector2 origin) =>
            vector + origin;

        /// <summary>
        /// Finds the Cross Product between this vector and given vector.
        /// </summary>
        /// <param name="vector1">This Vector2</param>
        /// <param name="vector2">Given Vector2.</param>
        /// <returns>Cross Product between two Vector2.</returns>
        public static float Cross(this Vector2 vector1, Vector2 vector2) =>
            (vector1.x * vector2.y) - (vector1.y * vector2.x);

        /// <summary>
        /// Returns a Vector2 Perpendiciular to the input.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        public static Vector2 Perp(this Vector2 vector) =>
            new Vector2(vector.y, -vector.x);

        /// <summary>
        /// Checks if this Vector2 is within a given distance from a given Vector2.
        /// </summary>
        /// <param name="vector">This Vector2.</param>
        /// <param name="distance">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is within. False if not within.</returns>
        public static bool IsWithin(this Vector2 vector, float distance, Vector2 origin) =>
            (vector - origin).sqrMagnitude < distance * distance;

        /// <summary>
        /// Checks if this Vector2 is beyond a given distance from a given Vector2.
        /// </summary>
        /// <param name="vector">This Vector2.</param>
        /// <param name="distance">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is beyond. False if not beyond.</returns>
        public static bool IsBeyond(this Vector2 vector, float distance, Vector2 origin) =>
            (vector - origin).sqrMagnitude > distance * distance;

        /// <summary>
        /// Sets the magnitude of a vector.
        /// </summary>
        /// <param name="vector">Vector2.</param>
        /// <param name="magnitude">Magnitude.</param>
        /// <returns>The vector with new magnitude.</returns>
        public static Vector2 SetMagnitude(this Vector2 vector, float magnitude) =>
            vector.normalized * magnitude;

        /// <summary>
        /// Round components to closest integers and convert to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2Int(this Vector2 vector) =>
            new Vector2Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()));

        /// <summary>
        /// Round components to closest integers and convert to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector2 vector) =>
            new Vector3Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()), 0);
    }

    /// <summary>
    /// Extension Methods used on Vector3.
    /// </summary>
    public static class Vector3E
    {
        /// <summary>
        /// Set x, y and/or z to any value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <param name="z">Value to set z to. (Optional)</param>
        /// <returns>Vector2 with changed values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Add any value to x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <param name="z">Value to add to z. (Optional)</param>
        /// <returns>Vector2 with added values.</returns>
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x + x ?? vector.x, vector.y + y ?? vector.y, vector.z + z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector3 Subtract(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x - x ?? vector.x, vector.y - y ?? vector.y, vector.z - z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector3 Multiply(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x * x ?? vector.x, vector.y * y ?? vector.y, vector.z * z ?? vector.z);

        /// <summary>
        /// Devide any value with x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to devide with x. (Optional)</param>
        /// <param name="y">Value to devide with y. (Optional)</param>
        /// <param name="z">Value to devide with z. (Optional)</param>
        /// <returns>Vector2 with devided values.</returns>
        public static Vector3 Divide(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x / x ?? vector.x, vector.y / y ?? vector.y, vector.z / z ?? vector.z);

        /// <summary>
        /// Flatten the vector to a given value on the y axis.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="flatLevel">Value to set y to. (Default = 0)</param>
        /// <returns>Vector3 with y set to 0 or set flat level.</returns>
        public static Vector3 Flat(this Vector3 vector, float flatLevel = 0) =>
            new Vector3(vector.x, flatLevel, vector.z);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector3.</returns>
        public static Vector3 DirectionTo3D(this Vector3 source, Vector3 destination) =>
            Vector3.Normalize(destination - source);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Transform.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector3.</returns>
        public static Vector3 DirectionTo3D(this Transform source, Vector3 destination) =>
            Vector3.Normalize(destination - source.position);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector3.</param>
        /// <param name="destination">Transform to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector3.</returns>
        public static Vector3 DirectionTo3D(this Vector3 source, Transform destination) =>
            Vector3.Normalize(destination.position - source);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Transform.</param>
        /// <param name="destination">Transform to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector3.</returns>
        public static Vector3 DirectionTo3D(this Transform source, Transform destination) =>
            Vector3.Normalize(destination.position - source.position);

        /// <summary>
        /// Rounds each axis of the vector to a whole number.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector3 rounded to whole numbers.</returns>
        public static Vector3 Round(this Vector3 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            vector.z = Mathf.Round(vector.z);
            return vector;
        }

        /// <summary>
        /// Rounds each axis of the vector to a multiple of a given value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="multiple">Multiple to round to.</param>
        /// <returns>Vector3 rounded to a multiple of a number.</returns>
        public static Vector3 Round(this Vector3 vector, float multiple) =>
            (vector / multiple).Round() * multiple;

        /// <summary>
        /// Converts a Vector3 to a Vector2.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 x and y coordinates.</returns>
        public static Vector2 ToVector2(this Vector3 vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Converts a Vector3 to a Vector2 using the x and y coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 x and y coordinates.</returns>
        public static Vector2 ToVector2XY(this Vector3 vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Converts a Vector3 to a Vector2 using the x and z coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 x and z coordinates.</returns>
        public static Vector2 ToVector2XZ(this Vector3 vector) =>
            new Vector2(vector.x, vector.z);

        /// <summary>
        /// Converts a Vector3 to a Vector2 using the y and z coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 y and z coordinates.</returns>
        public static Vector2 ToVector2YZ(this Vector3 vector) =>
            new Vector2(vector.y, vector.z);

        /// <summary>
        /// Finds the closest Vector3 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector3.</param>
        /// <returns>Closest Vector3 to target.</returns>
        public static Vector3 Closest(this Vector3 target, Vector3[] vectors)
        {
            Vector3 closest = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
            foreach (Vector3 vector in vectors)
            {
                float current = Vector3.Distance(target, vector);
                if (current < Vector3.Distance(target, closest))
                    closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Finds the farthest Vector3 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector3.</param>
        /// <returns>Farthest Vector3 from target.</returns>
        public static Vector3 Farthest(this Vector3 target, Vector3[] vectors)
        {
            Vector3 closest = Vector3.zero;
            foreach (Vector3 vector in vectors)
            {
                float current = Vector3.Distance(target, vector);
                if (current > Vector3.Distance(target, closest))
                    closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Find the average of an array of Vector3.
        /// </summary>
        /// <param name="vectors">Vector Array.</param>
        /// <returns>Average Vector3 from array.</returns>
        public static Vector3 Average(this Vector3[] vectors)
        {
            Vector3 average = Vector3.zero;
            foreach (Vector3 vector in vectors)
            {
                average += vector;
            }
            return average / vectors.Length;
        }

        /// <summary>
        /// Returns the vector with a set origin.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>Original Vector3 with new origin.</returns>
        public static Vector3 WithOrigin(this Vector3 vector, Vector3 origin) =>
            vector + origin;

        /// <summary>
        /// Generates a random Vector3 with values within -1 and 1 on each axis.
        /// </summary>
        /// <returns>Vector3 with random values for each axis.</returns>
        public static Vector3 RandomVector3()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Generates a random Vector3 with integer values within -1 and 1 on each axis.
        /// </summary>
        /// <returns>Vector3 with random values for each axis.</returns>
        public static Vector3 RandomDirection()
        {
            float x = (int)Random.Range(-1, 1);
            float y = (int)Random.Range(-1, 1);
            float z = (int)Random.Range(-1, 1);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Finds the Cross Product between this vector and given vector.
        /// </summary>
        /// <param name="vector1">This Vector3</param>
        /// <param name="vector2">Given Vector3.</param>
        /// <returns>Cross Product between two Vector2.</returns>
        public static Vector3 Cross(this Vector3 vector1, Vector2 vector2) =>
            Vector3.Cross(vector1, vector2);

        /// <summary>
        /// Returns a Vector2 Perpendiciular to the input.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        public static Vector3 Perp(this Vector3 vector) =>
            new Vector3(vector.y, -vector.x, 0f);

        /// <summary>
        /// Checks if this Vector3 is within a given distance from a given Vector3.
        /// </summary>
        /// <param name="vector">This Vector3.</param>
        /// <param name="distance">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is within. False if not within.</returns>
        public static bool IsWithin(this Vector3 vector, float distance, Vector3 origin) =>
            (vector - origin).sqrMagnitude < distance * distance;

        /// <summary>
        /// Checks if this Vector3 is beyond a given distance from a given Vector3.
        /// </summary>
        /// <param name="vector">This Vector3.</param>
        /// <param name="distance">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is beyond. False if not beyond.</returns>
        public static bool IsBeyond(this Vector3 vector, float distance, Vector3 origin) =>
            (vector - origin).sqrMagnitude > distance * distance;

        /// <summary>
        /// Sets the magnitude of a vector.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        /// <param name="magnitude">Magnitude.</param>
        /// <returns>The vector with new magnitude.</returns>
        public static Vector3 SetMagnitude(this Vector3 vector, float magnitude) =>
            vector.normalized * magnitude;

        /// <summary>
        /// Round components to closest integers and convert to Vector3Int.
        /// </summary>
        public static Vector3Int ToVector3Int(this Vector3 vector) =>
            new Vector3Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()), Convert.ToInt32(vector.z.Round()));

        /// <summary>
        /// Round components to closest integers and convert to Vector2Int.
        /// </summary>
        public static Vector2Int ToVector2Int(this Vector3 vector) =>
            new Vector2Int(Convert.ToInt32(vector.x.Round()), Convert.ToInt32(vector.y.Round()));
    }

    /// <summary>
    /// Extension Methods used on Vector2Ints.
    /// </summary>
    public static class Vector2IntE
    {
        /// <summary>
        /// Convert from Vector2Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2(this Vector2Int vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Convert from Vector2Int to Vector2.
        /// </summary>
        public static Vector2 ToVector2(this Vector3Int vector) =>
            new Vector2(vector.x, vector.y);
    }

    /// <summary>
    /// Extension Methods used on Vector3Ints.
    /// </summary>
    public static class Vector3IntE
    {
        /// <summary>
        /// Convert from Vector3Int to Vector3.
        /// </summary>
        public static Vector3 ToVector3(this Vector3Int vector) =>
            new Vector3(vector.x, vector.y, vector.z);

        /// <summary>
        /// Convert from Vector2Int to Vector3.
        /// </summary>
        public static Vector3 ToVector3(this Vector2Int vector) =>
            new Vector3(vector.x, vector.y, 0f);
    }

    /// <summary>
    /// Extension Methods used on Colors.
    /// </summary>
    public static class ColorE
    {
        /// <summary>
        /// Converts a color to a hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code with a preceeding #.</returns>
        public static string ToHexWithHash(this Color color) =>
            "#" + color.ToHex();

        /// <summary>
        /// Converts a color to a hex code.
        /// </summary>
        /// <param name="color">Color.</param>
        /// <returns>4 channel hex code.</returns>
        public static string ToHex(this Color color) =>
            ColorUtility.ToHtmlStringRGB(color);

        /// <summary>
        /// Sets any value of the color to a given value.
        /// </summary>
        /// <param name="color">Original Color.</param>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        /// <returns>Original Color with altered components.</returns>
        public static Color With(this Color color, float? r = null, float? g = null, float? b = null, float? a = null) =>
            new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
    }

    /// <summary>
    /// Extension Methods used on GameObjects.
    /// </summary>
    public static class GameObjectE
    {
        /// <summary>
        /// Gets the position of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Position of the GamObject as Vector3.</returns>
        public static Vector3 GetPosition(this GameObject obj) => 
            obj.transform.position;

        /// <summary>
        /// Gets the rotation of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Rotation of the GamObject as Quaternion.</returns>
        public static Quaternion GetRotation(this GameObject obj) => 
            obj.transform.rotation;

        /// <summary>
        /// Gets the scale of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Scale of the GamObject as Vector3.</returns>
        public static Vector3 GetScale(this GameObject obj) => 
            obj.transform.localScale;

        /// <summary>
        /// Returns all Components of all GameObjects.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="objs">GamObjects.</param>
        /// <returns>Array containing each GameObjects Component in order.</returns>
        public static T[] GetComponents<T>(this GameObject[] objs) where T : Component
        {
            T[] components = new T[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                var component = objs[i].GetComponent<T>();
                components[i] = component;
            }
            return components;
        }

        /// <summary>
        /// Returns all tags for all GameObjects.
        /// </summary>
        /// <param name="objs">GameObjects.</param>
        /// <returns>Array containing ceah GameObjects tag in order</returns>
        public static string[] GetTags(this GameObject[] objs)
        {
            string[] tags = new string[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                tags[i] = objs[i].tag;
            }
            return tags;
        }
    }

    /// <summary>
    /// Extension Methods used on Lists.
    /// </summary>
    public static class ListE
    {
        /// <summary>
        /// Remove an item from the list and return the item.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">List.</param>
        /// <param name="index">Index of the item that should be removed.</param>
        /// <returns>Removed item.</returns>
        public static T RemoveAndReturn<T>(this IList<T> list, int index) where T : List<T>
        {
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        /// <summary>
        /// Shuffle the contents of a list.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">List.</param>
        public static void Shuffle<T>(this IList<T> list) where T : List<T>
        {
            System.Random rng = new System.Random();
            int number = list.Count;
            while (number > 1)
            {
                number--;
                int k = rng.Next(number + 1);
                T value = list[k];
                list[k] = list[number];
                list[number] = value;
            }
        }

        /// <summary>
        /// Get a random item from a list.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">List.</param>
        /// <returns>Random item from a list</returns>
        public static T RandomItem<T>(this IList<T> list) where T : List<T>
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Remove random item from a list.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">List.</param>
        /// <returns>Removed item.</returns>
        public static T RemoveRandom<T>(this IList<T> list) where T : List<T>
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");

            int index = Random.Range(0, list.Count);
            return list.RemoveAndReturn(index);
        }
    }

    /// <summary>
    /// Extension Methods used on Transforms.
    /// </summary>
    public static class TransformE
    {
        /// <summary>
        /// Gets the positions from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Positions of each transform.</returns>
        public static Vector3[] Positions(this Transform[] transforms)
        {
            Vector3[] positions = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                positions[i] = transforms[i].position;
            }
            return positions;
        }

        /// <summary>
        /// Gets the rotations from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Rotations of each transform.</returns>
        public static Quaternion[] Rotations(this Transform[] transforms)
        {
            Quaternion[] rotation = new Quaternion[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                rotation[i] = transforms[i].rotation;
            }
            return rotation;
        }

        /// <summary>
        /// Gets the local scale from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Local scale of each transform.</returns>
        public static Vector3[] LocalScales(this Transform[] transforms)
        {
            Vector3[] localScales = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                localScales[i] = transforms[i].localScale;
            }
            return localScales;
        }

        /// <summary>
        /// Gets the lossy scale from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Lossy scale of each transform.</returns>
        public static Vector3[] LossyScales(this Transform[] transforms)
        {
            Vector3[] lossyScales = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                lossyScales[i] = transforms[i].lossyScale;
            }
            return lossyScales;
        }
    }

    /// <summary>
    /// Extension Methods used on Enums.
    /// </summary>
    public static class EnumE
    {
        /// <summary>
        /// Get a random value from an enum.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="e">Generic Variable.</param>
        /// <returns>Random enum value.</returns>
        public static T GetRandom<T>(this T e) where T : struct, System.IComparable
        {
            if (!(typeof(T).IsEnum))
                throw new ArgumentException("Value must be an enum");
            return (T)(object)Random.Range(1, System.Enum.GetNames(typeof(T)).Length);
        }

        /// <summary>
        /// Converts an enum to int.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="e">Generic Variable.</param>
        /// <returns>Int index of enum value.</returns>
        public static int ToInt<T>(this T e) where T : struct, System.IComparable
        {
            if (!(typeof(T).IsEnum))
                throw new ArgumentException("Argument must be an enum");
            return (int)(object)e;
        }
    }

    /// <summary>
    /// Extension Methods used on strings.
    /// </summary>
    public static class StringE
    {
        /// <summary>
        /// Removes any spaces in a string.
        /// </summary>
        /// <param name="text">String.</param>
        /// <returns>String with no spaces.</returns>
        public static string RemoveSpace(this string input)
        {
            return new string(input.ToCharArray()
            .Where(c => !char.IsWhiteSpace(c))
            .ToArray());
        }

        /// <summary>
        /// Converts string to Unity's Keycode enumeration.
        /// Cannot convert the symbols \ (write 'backslash' instead) and " (write 'double quotes' instead).
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>KeyCode.</returns>
        public static KeyCode ToKeyCode(this string key)
        {
            switch (key.ToLower().RemoveSpace())
            {
                case "":
                    return (KeyCode)0;
                case "backspace":
                    return (KeyCode)8;
                case "tab":
                    return (KeyCode)9;
                case "clear":
                    return (KeyCode)12;
                case "return":
                    return (KeyCode)13;
                case "pause":
                    return (KeyCode)19;
                case "escape":
                    return (KeyCode)27;
                case "space":
                    return (KeyCode)32;
                case " ":
                    return (KeyCode)32;
                case "exclaim":
                    return (KeyCode)33;
                case "!":
                    return (KeyCode)33;
                case "doublequote":
                    return (KeyCode)34;
                case "hash":
                    return (KeyCode)35;
                case "hashtag":
                    return (KeyCode)35;
                case "#":
                    return (KeyCode)35;
                case "dollar":
                    return (KeyCode)36;
                case "$":
                    return (KeyCode)36;
                case "percent":
                    return (KeyCode)37;
                case "%":
                    return (KeyCode)37;
                case "ampersand":
                    return (KeyCode)38;
                case "&":
                    return (KeyCode)38;
                case "quote":
                    return (KeyCode)39;
                case "'":
                    return (KeyCode)39;
                case "´":
                    return (KeyCode)39;
                case "leftparen":
                    return (KeyCode)40;
                case "leftparenthesis":
                    return (KeyCode)40;
                case "(":
                    return (KeyCode)40;
                case "rightparen":
                    return (KeyCode)41;
                case "rightparenthesis":
                    return (KeyCode)41;
                case ")":
                    return (KeyCode)41;
                case "asterisk":
                    return (KeyCode)42;
                case "*":
                    return (KeyCode)42;
                case "plus":
                    return (KeyCode)43;
                case "+":
                    return (KeyCode)43;
                case "comma":
                    return (KeyCode)44;
                case ",":
                    return (KeyCode)44;
                case "minus":
                    return (KeyCode)45;
                case "dash":
                    return (KeyCode)45;
                case "-":
                    return (KeyCode)45;
                case "period":
                    return (KeyCode)46;
                case ".":
                    return (KeyCode)46;
                case "dot":
                    return (KeyCode)46;
                case "slash":
                    return (KeyCode)47;
                case "/":
                    return (KeyCode)47;
                case "zero":
                    return (KeyCode)48;
                case "0":
                    return (KeyCode)48;
                case "one":
                    return (KeyCode)49;
                case "1":
                    return (KeyCode)49;
                case "two":
                    return (KeyCode)50;
                case "2":
                    return (KeyCode)50;
                case "three":
                    return (KeyCode)51;
                case "3":
                    return (KeyCode)51;
                case "four":
                    return (KeyCode)52;
                case "4":
                    return (KeyCode)52;
                case "five":
                    return (KeyCode)53;
                case "5":
                    return (KeyCode)53;
                case "six":
                    return (KeyCode)54;
                case "6":
                    return (KeyCode)54;
                case "seven":
                    return (KeyCode)55;
                case "7":
                    return (KeyCode)55;
                case "eight":
                    return (KeyCode)56;
                case "8":
                    return (KeyCode)56;
                case "nine":
                    return (KeyCode)57;
                case "9":
                    return (KeyCode)57;
                case "colon":
                    return (KeyCode)58;
                case ":":
                    return (KeyCode)58;
                case "semicolon":
                    return (KeyCode)59;
                case ";":
                    return (KeyCode)59;
                case "less":
                    return (KeyCode)60;
                case "<":
                    return (KeyCode)60;
                case "equal":
                    return (KeyCode)61;
                case "=":
                    return (KeyCode)61;
                case "greater":
                    return (KeyCode)62;
                case ">":
                    return (KeyCode)62;
                case "question":
                    return (KeyCode)63;
                case "?":
                    return (KeyCode)63;
                case "at":
                    return (KeyCode)64;
                case "@":
                    return (KeyCode)64;
                case "leftbracket":
                    return (KeyCode)91;
                case "[":
                    return (KeyCode)91;
                case "backslash":
                    return (KeyCode)92;
                case "rightbracket":
                    return (KeyCode)93;
                case "]":
                    return (KeyCode)93;
                case "caret":
                    return (KeyCode)94;
                case "^":
                    return (KeyCode)94;
                case "underscore":
                    return (KeyCode)95;
                case "_":
                    return (KeyCode)95;
                case "backquote":
                    return (KeyCode)96;
                case "`":
                    return (KeyCode)96;
                case "a":
                    return (KeyCode)97;
                case "b":
                    return (KeyCode)98;
                case "c":
                    return (KeyCode)99;
                case "d":
                    return (KeyCode)100;
                case "e":
                    return (KeyCode)101;
                case "f":
                    return (KeyCode)102;
                case "g":
                    return (KeyCode)103;
                case "h":
                    return (KeyCode)104;
                case "i":
                    return (KeyCode)105;
                case "j":
                    return (KeyCode)106;
                case "k":
                    return (KeyCode)107;
                case "l":
                    return (KeyCode)108;
                case "m":
                    return (KeyCode)109;
                case "n":
                    return (KeyCode)110;
                case "o":
                    return (KeyCode)111;
                case "p":
                    return (KeyCode)112;
                case "q":
                    return (KeyCode)113;
                case "r":
                    return (KeyCode)114;
                case "s":
                    return (KeyCode)115;
                case "t":
                    return (KeyCode)116;
                case "u":
                    return (KeyCode)117;
                case "v":
                    return (KeyCode)118;
                case "w":
                    return (KeyCode)119;
                case "x":
                    return (KeyCode)120;
                case "y":
                    return (KeyCode)121;
                case "z":
                    return (KeyCode)122;
                case "leftcurlybracket":
                    return (KeyCode)123;
                case "{":
                    return (KeyCode)123;
                case "pipe":
                    return (KeyCode)124;
                case "|":
                    return (KeyCode)124;
                case "rightcurlybracket":
                    return (KeyCode)124;
                case "}":
                    return (KeyCode)124;
                case "tilde":
                    return (KeyCode)126;
                case "~":
                    return (KeyCode)126;
                case "delete":
                    return (KeyCode)127;
                case "del":
                    return (KeyCode)127;
                case "num0":
                    return (KeyCode)256;
                case "numinsert":
                    return (KeyCode)256;
                case "num1":
                    return (KeyCode)257;
                case "numend":
                    return (KeyCode)257;
                case "num2":
                    return (KeyCode)258;
                case "numdownarrow":
                    return (KeyCode)258;
                case "num3":
                    return (KeyCode)259;
                case "numpgdn":
                    return (KeyCode)259;
                case "numpagedown":
                    return (KeyCode)259;
                case "num4":
                    return (KeyCode)260;
                case "numleftarrow":
                    return (KeyCode)260;
                case "num5":
                    return (KeyCode)261;
                case "num6":
                    return (KeyCode)262;
                case "numrightarrow":
                    return (KeyCode)262;
                case "num7":
                    return (KeyCode)263;
                case "numhome":
                    return (KeyCode)263;
                case "num8":
                    return (KeyCode)264;
                case "numuparrow":
                    return (KeyCode)264;
                case "num9":
                    return (KeyCode)265;
                case "numpgup":
                    return (KeyCode)265;
                case "numpageup":
                    return (KeyCode)265;
                case "numperiod":
                    return (KeyCode)266;
                case "numdot":
                    return (KeyCode)266;
                case "numdel":
                    return (KeyCode)266;
                case "numdelete":
                    return (KeyCode)266;
                case "num,":
                    return (KeyCode)266;
                case "numdivide":
                    return (KeyCode)267;
                case "numslash":
                    return (KeyCode)267;
                case "num/":
                    return (KeyCode)267;
                case "nummultiply":
                    return (KeyCode)268;
                case "numasterisk":
                    return (KeyCode)268;
                case "num*":
                    return (KeyCode)268;
                case "numminus":
                    return (KeyCode)269;
                case "num-":
                    return (KeyCode)269;
                case "numplus":
                    return (KeyCode)270;
                case "num+":
                    return (KeyCode)270;
                case "numenter":
                    return (KeyCode)271;
                case "numequals":
                    return (KeyCode)272;
                case "up":
                    return (KeyCode)273;
                case "uparrow":
                    return (KeyCode)273;
                case "down":
                    return (KeyCode)274;
                case "downarrow":
                    return (KeyCode)274;
                case "right":
                    return (KeyCode)275;
                case "rightarrow":
                    return (KeyCode)275;
                case "left":
                    return (KeyCode)276;
                case "leftarrow":
                    return (KeyCode)276;
                case "insert":
                    return (KeyCode)277;
                case "ins":
                    return (KeyCode)277;
                case "home":
                    return (KeyCode)278;
                case "end":
                    return (KeyCode)279;
                case "pgup":
                    return (KeyCode)280;
                case "pagegup":
                    return (KeyCode)281;
                case "pgdn":
                    return (KeyCode)281;
                case "pagegdown":
                    return (KeyCode)281;
                case "f1":
                    return (KeyCode)282;
                case "f2":
                    return (KeyCode)283;
                case "f3":
                    return (KeyCode)284;
                case "f4":
                    return (KeyCode)285;
                case "f5":
                    return (KeyCode)286;
                case "f6":
                    return (KeyCode)287;
                case "f7":
                    return (KeyCode)288;
                case "f8":
                    return (KeyCode)289;
                case "f9":
                    return (KeyCode)290;
                case "f10":
                    return (KeyCode)291;
                case "f11":
                    return (KeyCode)292;
                case "f12":
                    return (KeyCode)293;
                case "f13":
                    return (KeyCode)294;
                case "f14":
                    return (KeyCode)295;
                case "f15":
                    return (KeyCode)296;
                case "numlock":
                    return (KeyCode)300;
                case "num":
                    return (KeyCode)300;
                case "capslock":
                    return (KeyCode)300;
                case "caps":
                    return (KeyCode)301;
                case "scrolllock":
                    return (KeyCode)302;
                case "rightshift":
                    return (KeyCode)303;
                case "leftshift":
                    return (KeyCode)304;
                case "rightctrl":
                    return (KeyCode)305;
                case "rightcontrol":
                    return (KeyCode)305;
                case "leftctrl":
                    return (KeyCode)306;
                case "leftcontrol":
                    return (KeyCode)306;
                case "rightalt":
                    return (KeyCode)307;
                case "leftalt":
                    return (KeyCode)308;
                case "rightcommand":
                    return (KeyCode)309;
                case "rightapple":
                    return (KeyCode)309;
                case "leftcommand":
                    return (KeyCode)310;
                case "leftapple":
                    return (KeyCode)310;
                case "leftwindows":
                    return (KeyCode)311;
                case "rightwindows":
                    return (KeyCode)312;
                case "altgr":
                    return (KeyCode)313;
                case "help":
                    return (KeyCode)315;
                case "print":
                    return (KeyCode)316;
                case "printscreen":
                    return (KeyCode)316;
                case "prtsc":
                    return (KeyCode)316;
                case "sysrq":
                    return (KeyCode)317;
                case "sysreq":
                    return (KeyCode)317;
                case "break":
                    return (KeyCode)318;
                case "menu":
                    return (KeyCode)319;
                case "mouse0":
                    return (KeyCode)323;
                case "mouse1":
                    return (KeyCode)323;
                case "m1":
                    return (KeyCode)323;
                case "leftmouse":
                    return (KeyCode)323;
                case "leftmousebutton":
                    return (KeyCode)323;
                case "mouse2":
                    return (KeyCode)324;
                case "m2":
                    return (KeyCode)324;
                case "rightmouse":
                    return (KeyCode)324;
                case "rightmousebutton":
                    return (KeyCode)324;
                case "mouse3":
                    return (KeyCode)325;
                case "m3":
                    return (KeyCode)325;
                case "middlemouse":
                    return (KeyCode)325;
                case "middlemousebutton":
                    return (KeyCode)325;
                case "mouse4":
                    return (KeyCode)326;
                case "m4":
                    return (KeyCode)326;
                case "mouseback":
                    return (KeyCode)326;
                case "mouse5":
                    return (KeyCode)327;
                case "m5":
                    return (KeyCode)327;
                case "mousefront":
                    return (KeyCode)327;
                case "mouse6":
                    return (KeyCode)328;
                case "m6":
                    return (KeyCode)328;
                case "mouse7":
                    return (KeyCode)329;
                case "m7":
                    return (KeyCode)329;
            }
            return KeyCode.None;
        }
    }
}