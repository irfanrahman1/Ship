//using System.Numerics;
using UnityEngine;

public static class ScreenUtils
{
    // Saved for supporting resolution changes
    static int screenWidth;
    static int screenHeight;

    // Cached for efficient boundary checking
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    public static float ScreenLeft => screenLeft;
    public static float ScreenRight => screenRight;
    public static float ScreenTop => screenTop;
    public static float ScreenBottom => screenBottom;

    // Initialize or update screen boundary values
    public static void Initialize()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 topRightCornerScreen = new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
    }

}
