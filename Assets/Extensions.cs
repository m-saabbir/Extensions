using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void Active(this GameObject obj) => obj.SetActive(true);
    public static void Active(this Transform trans) => trans.gameObject.SetActive(true);
    public static void Inactive(this GameObject obj) => obj.SetActive(false);
    public static void Inactive(this Transform trans) => trans.gameObject.SetActive(false);
    public static void ResetRotation(this Transform trans) => trans.rotation = Quaternion.identity;
    public static void ResetLocalRotation(this Transform trans) => trans.localRotation = Quaternion.identity;
    public static void ResetPosition(this Transform trans) => trans.position = Vector3.zero;
    public static void ResetLocalPosition(this Transform trans) => trans.localPosition = Vector3.zero;
    public static void ResetPositionAndRotation(this Transform trans) => trans.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    public static void Relocate(this Transform trans, Transform target) => trans.SetPositionAndRotation(target.position, target.rotation);

    public static void ResetLocalPositionAndRotation(this Transform trans)
    {
        trans.localPosition = Vector3.zero;
        trans.localRotation = Quaternion.identity;

    }

    public static void RelocateLocal(this Transform trans, Transform target)
    {
        trans.localPosition = target.localPosition;
        trans.localRotation = target.localRotation;
    }

    public static void SwapWith(this GameObject obj, GameObject target)
    {
        obj.Inactive();
        target.Active();
    }

    public static void SwapWith(this Transform trans, Transform target)
    {
        trans.Inactive();
        target.Active();
    }

    public static Vector3 XZ(this Vector3 position)
    {
        position.y = 0f;
        return position;
    }

    public static Vector3 XZ(this Vector3 position, float y)
    {
        position.y = y;
        return position;
    }

    public static Quaternion LookRotationXZ(this Transform trans, Transform target)
    {
        Vector3 lookRotation = target.position.XZ() - trans.position;
        return Quaternion.LookRotation(lookRotation, Vector3.up);
    }

    public static void LookAtXZ(this Rigidbody rb, Transform target)
    {
        Vector3 lookRotation = target.position.XZ() - rb.position;
        rb.MoveRotation(Quaternion.LookRotation(lookRotation, Vector3.up));
    }

    public static void LookAt(this Rigidbody rb, Transform target)
    {
        Vector3 lookRotation = target.position - rb.position;
        rb.MoveRotation(Quaternion.LookRotation(lookRotation, Vector3.up));
    }

    public static void Throw(this Rigidbody rb, Vector3 target, float angle)
    {
        Vector3 direction = target - rb.position;
        direction.y = 0;
        float distanceXZ = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distanceXZ * Mathf.Tan(a);
        float vel = Mathf.Sqrt(distanceXZ * 9.81f / Mathf.Sin(2 * a));
        rb.AddForce(vel * direction.normalized, ForceMode.Impulse);
    }

    #region Log
    public static void Log(this string str, string colorCode = "FFFFFF") => Debug.Log($"<color=#{colorCode}>{str}</color>");
    public static void Log(this int str, string colorCode = "FFFFFF") => str.ToString().Log(colorCode);
    public static void Log(this long str, string colorCode = "FFFFFF") => str.ToString().Log(colorCode);
    public static void Log(this bool str, string colorCode = "FFFFFF") => str.ToString().Log(colorCode);
    public static void Log(this float str, string colorCode = "FFFFFF") => str.ToString().Log(colorCode);
    #endregion
}
