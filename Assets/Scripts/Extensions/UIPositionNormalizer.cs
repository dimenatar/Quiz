using UnityEngine;

public class UIPositionNormalizer
{
    private static readonly float WIDTH = 1080;
    private static readonly float HEIGHT = 1920;

    public static Vector2 GetNormalizedPosition(Vector2 position, float width, float height)
    {
        return new Vector2(position.x / width * WIDTH, position.y / height * HEIGHT);
    }
}
