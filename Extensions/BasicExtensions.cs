using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public static class BasicExtensions
{
    #region BASIC

    public static void Active(this GameObject go) => go.SetActive(true);
    public static void Inactive(this GameObject go) => go.SetActive(false);
    public static void Active(this Transform tr) => tr.gameObject.SetActive(true);
    public static void Inactive(this Transform tr) => tr.gameObject.SetActive(false);

    public static async void Active(this Transform tr, float delay)
    {
        await Task.Delay((int)(delay * 1000));
        tr.gameObject.SetActive(true);
    }

    public static async void Inactive(this Transform tr, float delay)
    {
        await Task.Delay((int)(delay * 1000));
        tr.gameObject.SetActive(false);
    }

    public static async void Active(this GameObject go, float delay)
    {
        await Task.Delay((int)(delay * 1000));
        go.SetActive(true);
    }

    public static async void Inactive(this GameObject go, float delay)
    {
        await Task.Delay((int)(delay * 1000));
        go.SetActive(false);
    }

    public static void Active(this GameObject[] go, bool clear = true)
    {
        for (int i = 0; i < go.Length; i++) go[i].Active();
        if (clear) Array.Clear(go, 0, go.Length);
    }

    public static void Inactive(this GameObject[] go, bool clear = true)
    {
        for (int i = 0; i < go.Length; i++) go[i].Inactive();
        if (clear) Array.Clear(go, 0, go.Length);
    }

    public static void Active(this Transform[] tr, bool clear = true)
    {
        for (int i = 0; i < tr.Length; i++) tr[i].Active();
        if (clear) Array.Clear(tr, 0, tr.Length);
    }

    public static void Inactive(this Transform[] tr, bool clear = true)
    {
        for (int i = 0; i < tr.Length; i++) tr[i].Inactive();
        if (clear) Array.Clear(tr, 0, tr.Length);
    }

    public static void SwapState(this GameObject go, GameObject target)
    {
        go.Inactive();
        target.Active();
    }

    public static void SwapState(this Transform tr, Transform target)
    {
        tr.Inactive();
        target.Active();
    }

    #endregion

    #region COROUTINE

    public static Coroutine DelayCall(this MonoBehaviour mono, float delay, Action action)
    {
        return mono.StartCoroutine(Execute());

        IEnumerator Execute()
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
    }

    #endregion

    #region MOVEMENT

    //  World Space
    public static void Move(this Transform tr, Transform target) => tr.position = target.position;
    public static void Move(this Transform tr, Vector3 target) => tr.position = target;
    public static void Move(this Transform tr, float x, float y, float z) => tr.position = new Vector3(x, y, z);
    public static void MoveX(this Transform tr, float x) => tr.position = new Vector3(x, tr.position.y, tr.position.z);
    public static void MoveY(this Transform tr, float y) => tr.position = new Vector3(tr.position.x, y, tr.position.z);
    public static void MoveZ(this Transform tr, float z) => tr.position = new Vector3(tr.position.x, tr.position.y, z);
    public static void ResetPosition(this Transform tr) => tr.position = Vector3.zero;
    public static void ResetRotation(this Transform tr) => tr.rotation = Quaternion.identity;
    public static void Reset(this Transform tr) => tr.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

    public static void Replace(this Transform tr, Transform target, bool swap = false)
    {
        tr.SetPositionAndRotation(target.position, target.rotation);
        if (swap) tr.SwapState(target);
    }
    

    //  Local Space
    public static void LocalMove(this Transform tr, Transform target) => tr.localPosition = target.localPosition;
    public static void LocalMove(this Transform tr, Vector3 target) => tr.localPosition = target;
    public static void LocalMove(this Transform tr, float x, float y, float z) => tr.localPosition = new Vector3(x, y, z);
    public static void LocalMoveX(this Transform tr, float x) => tr.localPosition = new Vector3(x, tr.localPosition.y, tr.localPosition.z);
    public static void LocalMoveY(this Transform tr, float y) => tr.localPosition = new Vector3(tr.localPosition.x, y, tr.localPosition.z);
    public static void LocalMoveZ(this Transform tr, float z) => tr.localPosition = new Vector3(tr.localPosition.x, tr.localPosition.y, z);
    public static void ResetLocalPosition(this Transform tr) => tr.localPosition = Vector3.zero;
    public static void ResetLocalRotation(this Transform tr) => tr.localRotation = Quaternion.identity;
    
    public static void ResetLocal(this Transform tr)
    {
        tr.localPosition = Vector3.zero;
        tr.localRotation = Quaternion.identity;
    }

    public static void ReplaceLocal(this Transform tr, Transform target, bool swap = false)
    {
        tr.localPosition = target.localPosition;
        tr.localRotation = target.localRotation;
        if (swap) tr.SwapState(target);
    }

    //  Common
    public static void RotateX(this Transform tr, float x, Space relativeTo = Space.Self) => tr.Rotate(x, 0f, 0f, relativeTo);
    public static void RotateY(this Transform tr, float y, Space relativeTo = Space.Self) => tr.Rotate(0f, y, 0f, relativeTo);
    public static void RotateZ(this Transform tr, float z, Space relativeTo = Space.Self) => tr.Rotate(0f, 0f, z, relativeTo);

    public static Quaternion LookRotationXZ(this Transform tr, Transform target) => Quaternion.LookRotation((target.position - tr.position).XZ());
    public static void LookAtXZ(this Transform tr, Transform target) => tr.LookAt(target.position.XZ());
    public static void LookAt(this Rigidbody rb, Transform target) => rb.MoveRotation(Quaternion.LookRotation((target.position - rb.position)));
    public static void LookAtXZ(this Rigidbody rb, Transform target) => rb.MoveRotation(Quaternion.LookRotation((target.position - rb.position).XZ()));

    #endregion

    #region PARTICLES

    public static void PlayAll(this ParticleSystem[] ps)
    {
        foreach (var p in ps) p.Play();
    }

    public static void StopAll(this ParticleSystem[] ps)
    {
        foreach (var p in ps) p.Stop();
    }

    #endregion
}
