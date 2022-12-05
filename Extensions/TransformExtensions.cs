using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void InactivateChildren(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public static void DestroyChildren(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            Object.Destroy(child.gameObject);
        }
    }

    public static List<Transform> GetChildren(this Transform transform)
    {
        List<Transform> transforms = new List<Transform>();

        foreach (Transform child in transform)
        {
            transforms.Add(child);
        }

        return transforms;
    }
}
