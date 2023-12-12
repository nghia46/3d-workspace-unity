using UnityEngine;

namespace Tools
{
    public abstract class CustomTools
    {
        public enum LogColor
        {
            Red,
            Blue,
            Yellow,
            White
        }

        public static void Log<T>(T logMessage, LogColor? color = null)
        {
            var colorCode = color?.ToString().ToLower() ?? LogColor.White.ToString().ToLower();
            Debug.Log($"<color={colorCode}>{logMessage}</color>");
        }
    }
}