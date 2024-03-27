using UnityEngine;

[System.Serializable]
public struct SerializableVector2Int
{
    public int x;
    public int y;

    public SerializableVector2Int(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static SerializableVector2Int FromUnityVector2(Vector2 vector2)
    {
        return new SerializableVector2Int
        {
            x = (int)vector2.x,
            y = (int)vector2.y
        };
    }

    public static SerializableVector2Int FromUnityVector2Int(Vector2Int vector2Int)
    {
        return new SerializableVector2Int
        {
            x = vector2Int.x,
            y = vector2Int.y
        };
    }

    public static Vector2 FromMyVector3(SerializableVector2Int serializableVector2Int)
    {
        var vector2Int = new Vector2Int(serializableVector2Int.x, serializableVector2Int.y);
        return vector2Int;
    }
}
