using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationKeyManager : MonoBehaviour
{
    public GameObject DiceObject;

    public void LeftRotation()
    {
        StartCoroutine(RotateDice(Vector3.up));
    }

    public void RightRotation()
    {
        StartCoroutine(RotateDice(Vector3.down));
    }

    public void ForwardRotation()
    {
        StartCoroutine(RotateDice(Vector3.right));
    }

    public void BackRotation()
    {
        StartCoroutine(RotateDice(Vector3.left));
    }

    public IEnumerator RotateDice(Vector3 Direction)
    {
        for (float i = 0; i < 9; i++)
        {
            DiceObject.transform.Rotate(Direction, 10f, Space.World);
            yield return new WaitForSeconds(0.004f);
        }
    }
}
