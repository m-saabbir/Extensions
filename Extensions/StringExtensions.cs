using UnityEngine;

public static class StringExtensions
{
    public static string Bold(this string text)
    {
        return $"<b>{text}</b>";
    }

    public static string Italic(this string text)
    {
        return $"<i>{text}</i>";
    }

    public static string Underline(this string text)
    {
        return $"<u>{text}</u>";
    }
    
    public static string Strikethrough(this string text)
    {
        return $"<s>{text}</s>";
    }

    public static string SetColor(this string text, Color color)
    {
        return $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
    }

    public static void Log(this object message, Color? rgb = null)
    {
        Color color = rgb ?? Color.white;
        Debug.LogFormat($"<color=#{(byte)(color.r * 255f):X2}{(byte)(color.g * 255f):X2}{(byte)(color.b * 255f):X2}>{message}</color>");
    }

    public static void Log(this object message, float r, float g, float b)
    {
        Debug.LogFormat($"<color=#{(byte)(r * 255f):X2}{(byte)(g * 255f):X2}{(byte)(b * 255f):X2}>{message}</color>");
    }
}