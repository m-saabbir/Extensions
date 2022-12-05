using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 XY(this Vector3 vector, float z = 0f)
    {
        vector.z = z;
        return vector;
    }

    public static Vector3 XZ(this Vector3 vector, float y = 0f)
    {
        vector.y = y;
        return vector;
    }

    public static Vector3 YZ(this Vector3 vector, float x = 0f)
    {
        vector.x = x;
        return vector;
    }

    public static Vector3 XY(this Vector2 vector, float z = 0f)
    {
        return new Vector3(vector.x, vector.y, z);
    }

    public static Vector2 X(this Vector2 vector, float y = 0f)
    {
        return new Vector2(vector.x, y);
    }

    public static Vector2 Y(this Vector2 vector, float x = 0f)
    {
        return new Vector2(x, vector.y);
    }

    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }
}