using System.Collections;
using System.Collections.Generic;

public static class CollectionExtensions
{
    public static T Random<T>(this T[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T Random<T>(this IList<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];

    }

    public static T RemoveRandom<T>(this IList<T> list)
    {
        int index = UnityEngine.Random.Range(0, list.Count);
        var item = list[index];
        list.RemoveAt(index);
        return item;
    }

    public static void Shuffle<T>(this T[] array)
    {
        var rng = new System.Random();

        for (int i = array.Length - 1; i > 1; i--)
        {
            int k = rng.Next(i);
            (array[i], array[k]) = (array[k], array[i]);
        }
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        var rng = new System.Random();

        for (int i = list.Count - 1; i > 1; i--)
        {
            int k = rng.Next(i);
            (list[i], list[k]) = (list[k], list[i]);
        }
    }
}
